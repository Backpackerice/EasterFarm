namespace EasterFarm.Models.MarketPlace
{
    using System;

    using EasterFarm.Models.Contracts;

    public abstract class Product : IBuyable, IStorable
    {
        private Enum type;
        private int price;
        private CurrencyType currency;

        public Product(Enum type, int price, CurrencyType currency)
        {
            this.Type = type;
            this.Price = price;
            this.Currency = currency;
        }

        public Enum Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                this.type = value;
            }           
        }

        public int Price
        {
            get
            {
                return this.price;
            }

            private set
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

            private set
            {
                this.currency = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0,-25} {1,6:c}", this.Type, this.Price);
        }
    }
}
