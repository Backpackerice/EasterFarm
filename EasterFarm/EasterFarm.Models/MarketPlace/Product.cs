namespace EasterFarm.Models.MarketPlace
{
    using System;

    using EasterFarm.Models.Contracts;

    public abstract class Product : IBuyable, IStorable
    {
        private Enum type;
        private int price;
        private Category category;

        public Product(Enum type, Category category, int price)
        {
            this.Type = type;
            this.Price = price;
            this.Category = category;
        }

        public Category Category
        {
            get
            {
                return this.category;
            }

            private set
            {
                this.category = value;
            }
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

        public override string ToString()
        {
            return string.Format("{0,-25} {1,6:c}", this.Type, this.Price);
        }
    }
}
