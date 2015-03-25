namespace EasterFarm.Models.Market
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public abstract class Product : IBuyable, IStorable
    {

        private Enum type;
        private int quantity; //може да е излишно ако маркета е с неограничени количества
        private int price;
        private MarketCurrency currency;

        public Product(Enum name, int price, MarketCurrency currency)
        {
            this.Type = type;
            this.Quantity = quantity;
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
       

        public int Quantity
        {
            get
            {
                return 100;
            }
            private set
            {

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

        public MarketCurrency Currency
        {
            get
            {
                return this.currency;
            }
            set
            {
                this.currency = value;
            }
        }

        


        public override string ToString()
        {
            return string.Format("{0,-25} {1,6:c}", Type, Price);


        }

       
    }
}
