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

        public GameInitializator()
        {
            this.gameObjects = new List<GameObject> 
            {
                new Raspberry(new MatrixCoords(1, 4)),
                new Blueberry(new MatrixCoords(20, 20)),
                new Hen(new MatrixCoords(10, 10)),
                new Hen(new MatrixCoords(9, 9)),
                new Hen(new MatrixCoords(15, 15)),
                new Hen(new MatrixCoords(8, 8))
            };
        }

        public void Initialize(FarmManager farmManager, Market market, PresentFactory presentFactory, HashSet<GameObject> farmObjects)
        {
            this.SetInitialGameObjects(farmManager, market, presentFactory);

            foreach (var gameObject in this.gameObjects)
            {
               farmObjects.Add(gameObject);
            }
        }

        private void SetInitialGameObjects(FarmManager farmManager, Market market, PresentFactory presentFactory)
        {
            farmManager = new FarmManager();

            market = new Market();
            var ingredientFactory = EasterFarm.Models.MarketPlace.MarketFactory.Get(Category.Ingredient);
            this.FillMarketCategory(ingredientFactory, IngredientType.Basket, market);

            presentFactory = new PresentFactory();
        }

        //Market
        //TODO : foreach category - more abstract?
        private void FillMarketCategory(ProductFactory productFactory, Enum productType, Market market)
        {
            foreach (Enum type in Enum.GetValues(productType.GetType()))
            {
                IBuyable ingredient = productFactory.Get(type);
                market.AddProduct(ingredient);
            }
        }
    }
}
