namespace EasterFarm.Models.MarketPlace
{
    using System;

    public class MarketFactory
    {
        public const string InvalidCategoryExcMsg = "Invalid product category. Are you sure you got the right one?";

        public static ProductFactory Get(Category category)
        {
            switch (category)
            {
                case Category.Ingredient:
                    return new IngredientFactory();
                default:
                    throw new InvalidOperationException(InvalidCategoryExcMsg);
            }
        }
    }
}
