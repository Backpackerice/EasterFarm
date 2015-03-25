namespace EasterFarm.Models.Market
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Market:Product
    {
        private IDictionary<string, decimal> productPrice;
        
        public Market(IngredientType name)
            :base( name)
        {

        }
        public decimal QuantityToBuy { get; set; }
      
        public decimal CalculateEveryCost()
        {
            return ((decimal)this.QuantityToBuy*base.Price);
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
