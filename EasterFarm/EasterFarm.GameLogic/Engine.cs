namespace EasterFarm.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using Contracts;
    using EasterFarm.Models;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Food;
    using EasterFarm.Models.FarmObjects.Animals;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.MarketPlace;
    using EasterFarm.Common;
using EasterFarm.Models.Presents;

    public class Engine
    {
        private IRenderer renderer;
        private IUserInput userInput;
        private FarmManager farmManager;
        private Market market;
        private PresentFactory presentFactory;

        private ICollection<GameObject> gameObjects;

        public Engine(IRenderer renderer, IUserInput userInput)
        {
            this.renderer = renderer;
            this.userInput = userInput;
            this.gameObjects = new List<GameObject>();
        }

        public void AddGameObject(GameObject gameObject)
        {
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
            }
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

                        var egg = new EasterEgg(livestock.TopLeft, new char[0, 0], color);
                        farmManager.AddToInventory(egg);
                        break;
                    case "Rabbit":
                        farmManager.AddToInventory(berry);
                        break;
                    case "Lamb":
                        var milk = new Milk(livestock.TopLeft, new char[0, 0]);
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
