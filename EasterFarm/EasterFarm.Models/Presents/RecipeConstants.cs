namespace EasterFarm.Models.Presents
{
    using System;
    using System.Collections.Generic;

    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.MarketPlace;

    public class RecipeConstants
    {
        private const int BasketAmmount = 1;
        private static readonly Dictionary<PresentType, Dictionary<Enum, int>> recipes;

        static RecipeConstants()
        {
            recipes = new Dictionary<PresentType, Dictionary<Enum, int>>
            {
                { PresentType.Kozunak, 
                    new Dictionary<Enum, int>
                    {
                        { ByproductType.EasterEgg, 2 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    }
                },
                { PresentType.ChocoEgg, 
                    new Dictionary<Enum, int>
                    {
                        { ByproductType.EasterEgg, 3 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Cocoa, 2 },
                        { ByproductType.Milk, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    }
                },
                { PresentType.Cookie, 
                    new Dictionary<Enum, int>
                    {
                        { ByproductType.EasterEgg, 2 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Cocoa, 2 },
                        { ByproductType.Milk, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    }
                },
                { PresentType.ChocoRabbit, 
                    new Dictionary<Enum, int>
                    {
                        { ByproductType.EasterEgg, 2 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Cocoa, 2 },
                        { ByproductType.Milk, 1 },
                        { IngredientType.Rabbit, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    } 
                },
                { PresentType.RabbitWithRibbon, 
                    new Dictionary<Enum, int>
                    {
                        { IngredientType.Rabbit, 1 },
                        { IngredientType.Ribbon, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    }
                }
            };
        }

        public static Dictionary<PresentType, Dictionary<Enum, int>> Recipes
        {
            get
            {
                return recipes;
            }
        }
    }
}
