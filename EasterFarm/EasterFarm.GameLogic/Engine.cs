using System.Runtime.Remoting.Channels;

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
        private FarmManager farmManager;
        private Market market;
        private PresentFactory presentFactory;

        private readonly ICollection<GameObject> gameObjects;
        private readonly ICollection<FarmFood> farmFoods;
        private readonly ICollection<Livestock> livestocks;
        private readonly ICollection<Villain> villains;

        public Engine(IRenderer renderer, IUserKeyboardInput userInput)
        {
            this.Renderer = renderer;
            this.UserInput = userInput;
            this.gameObjects = new List<GameObject>();
            this.farmFoods = new List<FarmFood>();
            this.livestocks = new List<Livestock>();
            this.villains = new List<Villain>();
        }

        internal IRenderer Renderer { get; private set; }

        internal IUserKeyboardInput UserInput { get; private set; }

        public void AddGameObject(GameObject gameObject)
        {
            var farmFood = gameObject as FarmFood;
            if (farmFood != null)
            {
                this.farmFoods.Add(farmFood);
            }
            var livestock = gameObject as Livestock;
            if (livestock != null)
            {
                this.livestocks.Add(livestock);
            }

            var villain = gameObject as Villain;
            if (villain != null)
            {
                this.villains.Add(villain);
            }

            this.gameObjects.Add(gameObject);
        }

        public void Start()
        {
            this.SetInitialGameObjects();

            while (true)
            {
                this.Renderer.RenderAll();

                Thread.Sleep(200);

                this.UserInput.ProcessInput();

                this.Renderer.ClearRenderer();

                foreach (var gameObject in gameObjects)
                {
                    this.Renderer.EnqueueForRendering(gameObject);
                }

                this.Seek(livestocks, typeof(FarmFood));
                this.Destroy(livestocks,farmFoods);

                this.Seek(villains, typeof(Livestock));
                this.Destroy(villains, livestocks);
            }
        }

        private void Destroy(IEnumerable<GameObject> destroyers, IEnumerable<GameObject> destroyables)
        {
            foreach (var destroyable in destroyables)
            {
                foreach (var destroyer in destroyers)
                {
                    if (destroyable.TopLeft == destroyer.TopLeft)
                    {
                        destroyable.IsDestroyed = true;
                    }
                }
            }

            //foreach (var destroyable in destroyables)
            //{
            //    this.gameObjects.Remove(destroyable);
            //}
        }

        private void Seek(IEnumerable<Animal> chasers, Type targetType)
        {
            var map = this.CreateTopographicMap(targetType);
            foreach (var chaser in chasers)
            {
                chaser.Move(map);
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

            this.market = Market.Instance;
            var ingredientFactory = EasterFarm.Models.MarketPlace.MarketFactory.Get(Category.Ingredient);
            this.FillMarketCategory(ingredientFactory, IngredientType.Basket);

            this.presentFactory = new PresentFactory();
        }

        // Market
        // TODO : foreach category - more abstract?
        private void FillMarketCategory(ProductFactory productFactory, Enum productType)
        {
            foreach (Enum type in Enum.GetValues(productType.GetType()))
            {
                IBuyable ingredient = productFactory.Get(type);
                this.market.AddProduct(ingredient);
            }
        }
    }
}
