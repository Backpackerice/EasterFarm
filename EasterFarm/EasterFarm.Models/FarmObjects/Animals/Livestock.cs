namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public abstract class Livestock : GameObject, IBuyable, IStorable, IMovable
    {
        protected Livestock(MatrixCoords topLeft, char[,] image) : base(topLeft, image)
        {
        }

        public Enum Type
        {
            get { throw new NotImplementedException(); }
        }

        public int Price
        {
            get { throw new NotImplementedException(); }
        }

        public Market.MarketCurrency Currency
        {
            get { throw new NotImplementedException(); }
        }
    }
}
