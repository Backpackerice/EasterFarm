namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;

    public abstract class Livestock : GameObject, IStorable, IMovable
    {
        protected Livestock(MatrixCoords topLeft, char[,] image)
            : base(topLeft, image)
        {
        }

        public abstract Livestock Clone();
    }
}