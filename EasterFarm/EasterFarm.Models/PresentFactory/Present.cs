namespace EasterFarm.Models.Presents
{
    using System;
    using System.Collections.Generic;

    using EasterFarm.Common;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.Market;

    public class Present : ISellable, IStorable
    {
        private const int NeededBaskets = 1;
        private readonly Dictionary<Enum, int> neededIngredients;

        private int value;
        private MarketCurrency currency;
        private Enum type;

        public Present(PresentType presentType, int value, MarketCurrency currency, Dictionary<Enum, int> ingredients)
        {
            this.Type = presentType;
            this.Value = value;
            this.Currency = currency;
            this.neededIngredients = new Dictionary<Enum, int>(ingredients);
        }

        public int Value
        {
            get
            {
                return this.value;
            }

            internal set
            {
                this.value = value;
            }
        }

        public MarketCurrency Currency
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
