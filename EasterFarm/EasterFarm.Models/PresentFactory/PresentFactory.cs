namespace EasterFarm.Models.Presents
{
    using System;
    using System.Collections.Generic;

    using EasterFarm.Common;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.MarketPlace;

    public class PresentFactory
    {
        private const int BasketAmmount = 1;

        private FarmManager producer;

        public PresentFactory(FarmManager producer)
        {
            this.Producer = producer;
        }

        public FarmManager Producer
        {
            get
            {
                return this.producer;
            }

            private set
            {
                this.producer = value;
            }
        }

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

                    this.GetIngredients(ingredients);

                    return new Present(PresentType.Kozunak, (int)PresentType.Kozunak, CurrencyType.Blueberries, ingredients);
                case PresentType.ChocoEgg:
                    ingredients = new Dictionary<Enum, int>
                    {
                        { ByproductType.PlainEgg, 3 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Cocoa, 2 },
                        { ByproductType.Milk, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    };

                    this.GetIngredients(ingredients);

                    return new Present(PresentType.ChocoEgg, (int)PresentType.ChocoEgg, CurrencyType.Blueberries, ingredients);
                case PresentType.Cookie:
                    ingredients = new Dictionary<Enum, int>
                    {
                        { ByproductType.PlainEgg, 2 },
                        { IngredientType.Flour, 1 },
                        { IngredientType.Cocoa, 2 },
                        { ByproductType.Milk, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    };

                    this.GetIngredients(ingredients);

                    return new Present(PresentType.Cookie, (int)PresentType.Cookie, CurrencyType.Blueberries, ingredients);
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

                    this.GetIngredients(ingredients);

                    return new Present(PresentType.ChocoRabbit, (int)PresentType.ChocoRabbit, CurrencyType.Raspberries, ingredients);
                case PresentType.RabbitWithRibbon:
                    ingredients = new Dictionary<Enum, int>
                    {
                        { LivestockType.Rabbit, 1 },
                        { IngredientType.Ribbon, 1 },
                        { IngredientType.Basket, BasketAmmount }
                    };

                    this.GetIngredients(ingredients);

                    return new Present(PresentType.RabbitWithRibbon, (int)PresentType.RabbitWithRibbon, CurrencyType.Raspberries, ingredients);
                default:
                    return null;
            }
        }

        private void GetIngredients(Dictionary<Enum, int> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                var item = this.Producer.GetFromInventoryByType(ingredient.Key);
                if (item != null)
                {
                    this.Producer.SubtractFromInventoryItem(item, ingredient.Value);
                }
                else
                {
                    throw new InsufficientAmmountException(ingredient.Key.ToString());
                }
            }
        }
    }
}
