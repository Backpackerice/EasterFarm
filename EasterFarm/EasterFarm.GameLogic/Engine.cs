namespace EasterFarm.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using Contracts;
    using EasterFarm.Common;
    using EasterFarm.Models;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Food;
    using EasterFarm.Models.FarmObjects.Animals;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.MarketPlace;
	using EasterFarm.Models.Presents;

    public class Engine
    {
        private IRenderer renderer;
        private IUserInput userInput;
        private FarmManager farmManager;
        private Market market;
        private PresentFactory presentFactory;

        private ICollection<GameObject> gameObjects;
        private ICollection<IMovable> movingObjects;

        public Engine(IRenderer renderer, IUserInput userInput)
        {
            this.renderer = renderer;
            this.userInput = userInput;
            this.gameObjects = new List<GameObject>();
            this.movingObjects = new List<IMovable>();
        }

        public void AddGameObject(GameObject gameObject)
        {
            if (gameObject is IMovable)
            {
                this.movingObjects.Add(gameObject as IMovable);
            }

            this.gameObjects.Add(gameObject);

        }

        public void Start()
        {
            this.SetInitialGameObjects();

            while (true)
            {
                this.renderer.RenderAll();

                Thread.Sleep(200);

                this.userInput.ProcessInput();

                this.renderer.ClearRenderer();

                foreach (var gameObject in gameObjects)
                {
                    this.renderer.EnqueueForRendering(gameObject);
                }

                int[,] map = CreateTopographicMap(typeof(FarmFood));

                foreach (IMovable movingObject in movingObjects)
                {
                    movingObject.Move(map);
                }
            }
        }

        private int[,] CreateTopographicMap(Type gameObjectType)
        {
            int[,] map = new int[Constants.WorldRows, (int)(Constants.WorldCols * Constants.LeftRightScreenRatio) + 1];
            int mapHeight = map.GetLength(0);
            int mapWidth = map.GetLength(1);

            for (int row = 1; row < mapHeight - 1; row++)
            {
                for (int col = 1; col < mapWidth - 1; col++)
                {
                    map[row, col] = -1;
                }
            }

            for (int row = 0; row < mapHeight; row++)
            {
                map[row, 0] = int.MaxValue;
                map[row, mapWidth - 1] = int.MaxValue;
            }

            for (int col = 1; col < mapWidth - 1; col++)
            {
                map[0, col] = int.MaxValue;
                map[mapHeight - 1, col] = int.MaxValue;
            }

            Queue<MatrixCoords> queue = new Queue<MatrixCoords>();

            foreach (var gameObject in this.gameObjects)
            {
                if (gameObject.GetType().IsSubclassOf(gameObjectType) || gameObject.GetType() == gameObjectType)
                {
                    map[gameObject.TopLeft.Row, gameObject.TopLeft.Col] = 0;
                    queue.Enqueue(gameObject.TopLeft);
                }
            }

            while (queue.Count > 0)
            {
                MatrixCoords currentCoords = queue.Dequeue();
                int row = currentCoords.Row;
                int col = currentCoords.Col;
                for (int i = (row - 1 > 0 ? row - 1 : 0); i <= (row + 1 <= mapHeight - 1 ? row + 1 : mapHeight - 1); i++)
                {
                    for (int j = (col - 1 > 0 ? col - 1 : 0); j <= (col + 1 <= mapWidth - 1 ? col + 1 : mapWidth - 1); j++)
                    {
                        if (map[i, j] == -1)
                        {
                            map[i, j] = map[row, col] + 1;
                            queue.Enqueue(new MatrixCoords(i, j));
                        }
                    }
                }
            }

            return map;
        }

        public void SetInitialGameObjects()
        {
            this.farmManager = new FarmManager();
            this.market = new Market();
            var productFactory = new ProductFactory();
            this.FillMarket(productFactory);
            this.presentFactory = new PresentFactory(farmManager);
        }

        // Farm
        // TODO : move each method to each livestock class
        public void HandleCollisionWithBerry(Livestock livestock, FarmFood berry)
        {
            berry.IsDestroyed = true;

            if (!berry.IsSpoilt)
            {
                var livestockType = livestock.GetType().ToString();
                switch (livestockType)
                {
                    case "Hen":
                        EggColor color = EggColor.None;

                        if ((FarmFoodType)berry.Type == FarmFoodType.Blueberry)
                        {
                            color = EggColor.Blue;
                        }
                        else if ((FarmFoodType)berry.Type == FarmFoodType.Raspberry)
                        {
                            color = EggColor.Red;
                        }

                        var egg = new EasterEgg(livestock.TopLeft, color);
                        farmManager.AddToInventory(egg);
                        break;
                    case "Rabbit":
                        farmManager.AddToInventory(berry);
                        break;
                    case "Lamb":
                        var milk = new Milk(livestock.TopLeft);
                        farmManager.AddToInventory(milk);
                        break;
                }
            }
        }

        // Market
        public void BuyProducts(IBuyable product, int quantity)
        {
            int cost = this.market.CalculateCost(product, quantity);
            var currency = this.farmManager.GetFromInventoryByType(FarmFoodType.Raspberry);

            if (currency != null && this.farmManager.Inventory[currency] >= cost)
            {
                this.farmManager.Inventory[currency] -= cost;
            }
            else
            {
                throw new InsufficientAmmountException(currency.ToString());
            }

            this.farmManager.AddToInventory(product);
        }

        public void SellProducts(ISellable product, int quantity)
        {
            int income = this.market.CalculateCost(product, quantity);
            var currency = this.farmManager.GetFromInventoryByType(FarmFoodType.Raspberry);

            this.farmManager.RemoveFromInventory(product);
            this.farmManager.AddMultipleToInventory(currency, income);
        }

        // TODO : foreach category?
        private void FillMarket(ProductFactory productFactory)
        {
            foreach (IngredientType ingredientType in Enum.GetValues(typeof(IngredientType)))
            {
                IBuyable product = productFactory.Get(ingredientType);
                this.market.AddProduct(product);
            }
        }
    }
}
