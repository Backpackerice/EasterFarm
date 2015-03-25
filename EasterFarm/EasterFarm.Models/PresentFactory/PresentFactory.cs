namespace EasterFarm.Models.Presents
{
    using System;
    using System.Collections.Generic;
    
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.Market;

    public class PresentFactory
    {
        private const int BasketAmmount = 1;

        public Present Get(PresentType presentType)
        {
            Dictionary<Enum, int> ingredients;

            switch (presentType)
            {
                case PresentType.Kozunak:
                    ingredients = new Dictionary<Enum, int>
                    {
                        { ByproductType.PlainEgg, 2 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    };

                    return new Present(PresentType.Kozunak, (int)PresentType.Kozunak, MarketCurrency.Blueberries, ingredients);
                case PresentType.ChocoEgg:
                    ingredients = new Dictionary<Enum, int>
                    {
                        { ByproductType.PlainEgg, 3 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Cocoa, 2 },
                        { ByproductType.Milk, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    };

                    return new Present(PresentType.ChocoEgg, (int)PresentType.ChocoEgg, MarketCurrency.Blueberries, ingredients);
                case PresentType.Cookie:
                    ingredients = new Dictionary<Enum, int>
                    {
                        { ByproductType.PlainEgg, 2 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Cocoa, 2 },
                        { ByproductType.Milk, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    };

                    return new Present(PresentType.Cookie, (int)PresentType.Cookie, MarketCurrency.Blueberries, ingredients);
                case PresentType.ChocoRabbit:
                    ingredients = new Dictionary<Enum, int>
                    {
                        { ByproductType.PlainEgg, 2 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Cocoa, 2 },
                        { ByproductType.Milk, 1 },
                        { LivestockType.Rabbit, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    };

                    return new Present(PresentType.ChocoRabbit, (int)PresentType.ChocoRabbit, MarketCurrency.Raspberries, ingredients);
                case PresentType.RabbitWithRibbon:
                    ingredients = new Dictionary<Enum, int>
                    {
                        { LivestockType.Rabbit, 1 },
                        { IngredientType.Ribbon, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    };

                    return new Present(PresentType.RabbitWithRibbon, (int)PresentType.RabbitWithRibbon, MarketCurrency.Raspberries, ingredients);
                default:
                    return null;
            }
        }
    }
}
