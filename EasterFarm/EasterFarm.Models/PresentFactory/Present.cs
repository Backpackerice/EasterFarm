namespace EasterFarm.Models.Presents
{
    using System;
    using System.Collections.Generic;

    using EasterFarm.Common;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;

    public class Present : ISellable, IStorable
    {
        private const int NeededBaskets = 1;
        private readonly Dictionary<Enum, int> neededIngredients;

        private int price;
        private CurrencyType currency;
        private Enum type;

        public Present(PresentType presentType, int price, CurrencyType currency, Dictionary<Enum, int> ingredients)
        {
            this.Type = presentType;
            this.Price = price;
            this.Currency = currency;
            this.neededIngredients = new Dictionary<Enum, int>(ingredients);
        }

        public int Price
        {
            get
            {
                return this.price;
            }

            internal set
            {
                this.price = value;
            }
        }

        public CurrencyType Currency
        {
            get
            {
                return this.currency;
            }

            internal set
            {
                this.currency = value;
            }
        }

        public Enum Type
        {
            get
            {
                return this.type;
            }

            internal set
            {
                this.type = value;
            }
        }

        public Dictionary<Enum, int> NeededIngredients
        {
            get
            {
                return this.neededIngredients;
            }
        }
    }
}
