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

        private IngredientType name;
        private int quantity;
        private decimal price;

       public Product(IngredientType name)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
        }

       public IngredientType Name { get; set; }

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

        public decimal Price
        {
            get
            {
                if (Name == IngredientType.Flour)
                {
                    return 2;
                }
                else if (Name == IngredientType.Cocoa)
                {
                    return 4;
                }
                else if (Name == IngredientType.Ribbon)
                {
                    return 8;
                }
                else if (Name == IngredientType.Basket)
                {
                    return 12;
                }
                else if (Name == IngredientType.Berries)
                {
                    return 1;
                }
                else if (Name == IngredientType.Rabbit)
                {
                    return 15;
                }
                else if (Name == IngredientType.Hen)
                {
                    return 25;
                }
                else if (Name == IngredientType.Milk)
                {
                    return 2;
                }
                else
                {
                    return 2;
                }
            }

            private set
            {

            }
        }

        public abstract decimal CalculateEveryCost();
       

        public override string ToString()
        {
            return string.Format("{0,-25} {1,6:c}", Name, Price);

      
        }
    }
}
