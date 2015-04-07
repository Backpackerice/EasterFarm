namespace EasterFarm.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.FarmObjects.Animals;
    using EasterFarm.Models;
    using EasterFarm.Models.FarmObjects.Food;
    using EasterFarm.Models.MarketPlace;
    using EasterFarm.Models.Presents;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Byproducts;

    public class GameInitializator
    {
        private IList<GameObject> gameObjects;
        private IList<IStorable> inventoryItems;
        private IList<IBuyable> marketIngredients;
        private IList<IStorable> presents;
        private ProductFactory ingredientFactory;
        private PresentFactory presentFactory;

        public GameInitializator()
        {

            this.ingredientFactory = EasterFarm.Models.MarketPlace.MarketFactory.Get(Category.Ingredient);
            this.presentFactory = new PresentFactory();

            this.gameObjects = new List<GameObject> 
            {               
                new Raspberry(new MatrixCoords(10, 10)),
                new Blueberry(new MatrixCoords(20, 5)),
                new Raspberry(new MatrixCoords(20, 25)),
                new Hen(new MatrixCoords(1, 4)),
                new Hen(new MatrixCoords(9, 9)),
                new Lamb(new MatrixCoords(20, 20)),
                new Lamb(new MatrixCoords(5, 20)),
                new Rabbit(new MatrixCoords(12, 12)),
                new Rabbit(new MatrixCoords(2, 20)),
            };

            this.inventoryItems = new List<IStorable>
            {
                new Raspberry(),
                new Hen(),
                new Rabbit(),
                new Lamb(),
                new EasterEgg(ByproductColor.Blue),
                new EasterEgg(ByproductColor.Red),
                new TrophyEgg(ByproductColor.Blue),
                new TrophyEgg(ByproductColor.Red),
                new Milk(),
            };

            this.marketIngredients = new List<IBuyable>();
            this.FillIngredients();

            this.presents = new List<IStorable>();
            this.FillPresents();
        }

        public void Initialize(FarmManager farmManager, Market market, PresentFactory presentFactory, ICollection<GameObject> farmObjects)
        {
            this.FillGameObjectCollection(farmObjects);
            this.FillMarketIngredients(market);
            this.FillInventory(farmManager);
        }

        private void FillPresents()
        {
            foreach (PresentType type in Enum.GetValues(typeof(PresentType)))
            {
                this.presents.Add(presentFactory.Get(type));
            }
        }

        private void FillIngredients()
        {
            foreach (IngredientType type in Enum.GetValues(typeof(IngredientType)))
            {
                this.marketIngredients.Add(ingredientFactory.Get(type));
            }
        }

        private void FillMarketIngredients(Market market)
        {
            foreach (var ingredient in this.marketIngredients)
            {
                market.AddProduct(ingredient);
            }
        }

        private void FillGameObjectCollection(ICollection<GameObject> farmObjects)
        {
            foreach (var gameObject in this.gameObjects)
            {
                farmObjects.Add(gameObject);
            }
        }

        private void FillInventory(FarmManager farmManager)
        {
            foreach (var item in this.inventoryItems)
            {
                farmManager.AddMultipleToInventory(item, 5);
            }

            foreach (var ingredient in this.marketIngredients)
            {
                farmManager.AddMultipleToInventory(ingredient, 5);
            }

            foreach (var present in this.presents)
            {
                farmManager.AddToInventory(present);
            }
        }
    }
}
