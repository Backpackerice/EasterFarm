namespace EasterFarm.Models.PresentFactory
{
    using System.Collections.Generic;

    using EasterFarm.Models.Market;

    public class PresentFactory
    {
        private const int BasketAmmount = 1;

        public static Present Get(PresentType presentType, FarmManager producer)
        {
            Dictionary<IngredientType, int> ingredients;

            switch (presentType)
            {
                case PresentType.Kozunak:
                    ingredients = new Dictionary<IngredientType, int>
                    {
                        { IngredientType.Egg, 2 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    };

                    return new Present(PresentType.Kozunak, (int)PresentType.Kozunak, MarketCurrency.Blueberries, producer, ingredients);
                case PresentType.ChocoEgg:
                    ingredients = new Dictionary<IngredientType, int>
                    {
                        { IngredientType.Egg, 3 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Cocoa, 2 },
                        { IngredientType.Milk, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    };

                    return new Present(PresentType.ChocoEgg, (int)PresentType.ChocoEgg, MarketCurrency.Blueberries, producer, ingredients);
                case PresentType.Cookie:
                    ingredients = new Dictionary<IngredientType, int>
                    {
                        { IngredientType.Egg, 2 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Cocoa, 2 },
                        { IngredientType.Milk, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    };

                    return new Present(PresentType.Cookie, (int)PresentType.Cookie, MarketCurrency.Blueberries, producer, ingredients);
                case PresentType.ChocoRabbit:
                    ingredients = new Dictionary<IngredientType, int>
                    {
                        { IngredientType.Egg, 2 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Cocoa, 2 },
                        { IngredientType.Milk, 1 },
                        { IngredientType.Rabbit, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    };

                    return new Present(PresentType.ChocoRabbit, (int)PresentType.ChocoRabbit, MarketCurrency.Raspberries, producer, ingredients);
                case PresentType.RabbitWithRibbon:
                    ingredients = new Dictionary<IngredientType, int>
                    {
                        { IngredientType.Rabbit, 1 },
                        { IngredientType.Ribbon, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    };

                    return new Present(PresentType.RabbitWithRibbon, (int)PresentType.RabbitWithRibbon, MarketCurrency.Raspberries, producer, ingredients);
                default:
                    return null;
            }
        }
    }
}
