namespace EasterFarm.Models.MarketPlace
{
    using System;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Animals;

    public class ProductFactory
    {
        public IBuyable Get(Enum productType)
        {
            IngredientType ingredientType;
            //LivestockType livestockType;

            if (Enum.TryParse(productType.ToString(), out ingredientType))
            {
                switch (ingredientType)
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
                }
            }
            //else if (Enum.TryParse(productType.ToString(), out livestockType))
            //{
            //    switch (livestockType)
            //    {
            //        case LivestockType.Hen:
            //            return new Hen(new MatrixCoords(0, 0), new char[0, 0]);
            //        case LivestockType.Lamb:
            //            return new Lamb(new MatrixCoords(0, 0), new char[0, 0]);
            //        case LivestockType.Rabbit:
            //            return new Rabbit(new MatrixCoords(0, 0), new char[0, 0]);
            //    }
            //}

            return null;
        }
    }
}
