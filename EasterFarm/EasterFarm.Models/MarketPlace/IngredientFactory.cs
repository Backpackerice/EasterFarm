namespace EasterFarm.Models.MarketPlace
{
    using System;

    using EasterFarm.Models.Contracts;

    public class IngredientFactory : ProductFactory
    {
        public const string InvalidProductTypeExcMsg = "The ingredient you're trying to make cannot currently be produced by this factory.";

        public override IBuyable Get(Enum productType)
        {
            switch ((IngredientType)productType)
            {
                case IngredientType.Basket:
                    return new Ingredient(IngredientType.Basket, (int)IngredientType.Basket);
                case IngredientType.Cocoa:
                    return new Ingredient(IngredientType.Cocoa, (int)IngredientType.Cocoa);
                case IngredientType.Ribbon:
                    return new Ingredient(IngredientType.Ribbon, (int)IngredientType.Ribbon);
                case IngredientType.Flour:
                    return new Ingredient(IngredientType.Flour, (int)IngredientType.Flour);
                case IngredientType.Rabbit:
                    return new Ingredient(IngredientType.Rabbit, (int)IngredientType.Rabbit);
                default:
                    throw new InvalidOperationException(InvalidProductTypeExcMsg);
            }
        }
    }
}
