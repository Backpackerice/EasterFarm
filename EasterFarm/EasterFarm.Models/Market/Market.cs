namespace EasterFarm.Models.Market
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Market:Product
    {
        private IDictionary<IngredientType, decimal> productWithPrice;

        private int quantity;

        public Market(IngredientType name,int price, MarketCurrency currency ,int quantity)
            :base(name,price, currency)
        {
            this.QuantityToBuy = quantity;
        }
        public int  QuantityToBuy
        {
            get
            {
                return this.quantity;
            }
            set
            {
                if(value<0)
                {
                    throw new ArgumentException("Quantity which you want to buy less then 1 product!");
                }
                this.quantity = value;
            }

        }
      
        public  int CalculateEveryCost()
        {
            return ((int)this.QuantityToBuy*base.Price);
        }

        
        public decimal CalculateFullCost()
        {
            //TODO: total cost in market
            return 0;
        }
        public override string ToString()
        {
            return string.Format("Total cost:{0,6:c}",CalculateFullCost());
        }





     
    }
}
