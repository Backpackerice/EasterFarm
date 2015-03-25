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
        public Enum Type
        {
            get { throw new NotImplementedException(); }
        }

        public int Price
        {
            get { throw new NotImplementedException(); }
        }

        public MarketCurrency Currency
        {
            get { throw new NotImplementedException(); }
        }
    }
}
