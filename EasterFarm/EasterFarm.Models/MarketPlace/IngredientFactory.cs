namespace EasterFarm.Models.MarketPlace
{
    using System;

    using EasterFarm.Models.Contracts;

    public class IngredientFactory : ProductFactory
    {
        public override IBuyable Get(Enum productType)
        {
            switch ((IngredientType)productType)
            {
                case IngredientType.Basket:
                    return new Ingredient(IngredientType.Basket, Category.Ingredient, (int)IngredientType.Basket);
                case IngredientType.Cocoa:
                    return new Ingredient(IngredientType.Cocoa, Category.Ingredient, (int)IngredientType.Cocoa);
                case IngredientType.Ribbon:
                    return new Ingredient(IngredientType.Ribbon, Category.Ingredient, (int)IngredientType.Ribbon);
                case IngredientType.Flour:
                    return new Ingredient(IngredientType.Flour, Category.Ingredient, (int)IngredientType.Flour);
                case IngredientType.Rabbit:
                    return new Ingredient(IngredientType.Rabbit, Category.Ingredient, (int)IngredientType.Rabbit);
                default:
                    return null;
            }
        }
    }
}
