namespace EasterFarm.Models.MarketPlace
{
    using System;

    using EasterFarm.Models.Contracts;
    
    public class MarketFactory
    {
        public static ProductFactory Get(Category category)
        {
            switch (category)
            {
                case Category.Ingredient:
                    return new IngredientFactory();
                default:
                    return null;
            }
        }
    }
}
