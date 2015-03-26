namespace EasterFarm.Models.MarketPlace
{
    using System;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Animals;

    public class ProductFactory
    {
        public IStorable Get(Enum productType)
        {
            IngredientType ingredientType;
            LivestockType livestockType;

            if (Enum.TryParse(productType.ToString(), out ingredientType))
            {
                switch (ingredientType)
                {
                    case IngredientType.Basket:
                        return new Ingredient(IngredientType.Basket, (int)IngredientType.Basket, CurrencyType.Blueberry);
                    case IngredientType.Cocoa:
                        return new Ingredient(IngredientType.Cocoa, (int)IngredientType.Cocoa, CurrencyType.Raspberry);
                    case IngredientType.Ribbon:
                        return new Ingredient(IngredientType.Ribbon, (int)IngredientType.Ribbon, CurrencyType.Blueberry);
                    case IngredientType.Flour:
                        return new Ingredient(IngredientType.Flour, (int)IngredientType.Flour, CurrencyType.Raspberry);
                }
            }
            else if (Enum.TryParse(productType.ToString(), out livestockType))
            {
                switch (livestockType)
                {
                    case LivestockType.Hen:
                        return new Hen(new MatrixCoords(0, 0), new char[0, 0]);
                    case LivestockType.Lamb:
                        return new Lamb(new MatrixCoords(0, 0), new char[0, 0]);
                    case LivestockType.Rabbit:
                        return new Rabbit(new MatrixCoords(0, 0), new char[0, 0]);
                }
            }

            return null;
        }
    }
}
