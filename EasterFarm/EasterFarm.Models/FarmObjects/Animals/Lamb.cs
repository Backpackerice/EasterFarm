namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public class Lamb : Livestock, IEatBerries, IBuyable, IStorable, IMovable
    {
        public Lamb(MatrixCoords topLeft, char[,] image) : base(topLeft, image)
        {
        }

        public void EatBerry()
        {
            throw new NotImplementedException();
        }
    }
}
