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
        private static readonly Dictionary<PresentType, Dictionary<Enum, int>> recepies;

        static PresentFactory()
        {
            recepies = new Dictionary<PresentType, Dictionary<Enum, int>>
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

        public PresentFactory()
        {
        }

        public Dictionary<PresentType, Dictionary<Enum, int>> Recepies 
        {
            get
            {
                return recepies;
            }
        }

        public Present Get(PresentType presentType)
        {
            switch (presentType)
            {
                case PresentType.Kozunak:
                    return new Present(PresentType.Kozunak, (int)PresentType.Kozunak, recepies[PresentType.Kozunak]);
                case PresentType.ChocoEgg:
                    return new Present(PresentType.ChocoEgg, (int)PresentType.ChocoEgg, recepies[PresentType.ChocoEgg]);
                case PresentType.Cookie:
                    return new Present(PresentType.Cookie, (int)PresentType.Cookie, recepies[PresentType.Cookie]);
                case PresentType.ChocoRabbit:
                    return new Present(PresentType.ChocoRabbit, (int)PresentType.ChocoRabbit, recepies[PresentType.ChocoRabbit]);
                case PresentType.RabbitWithRibbon:
                    return new Present(PresentType.RabbitWithRibbon, (int)PresentType.RabbitWithRibbon, recepies[PresentType.RabbitWithRibbon]);
                default:
                    return null;
            }
        }
    }
}
