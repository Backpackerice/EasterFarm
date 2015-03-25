namespace EasterFarm.Models.Market
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public class Ingredient : Product, ICookable
    {
        //задължителен конструктор от наследяването
        public Ingredient(IngredientType name, int price, MarketCurrency currency)
            :base(name,price, currency)
        {
            
        }
    }
}
