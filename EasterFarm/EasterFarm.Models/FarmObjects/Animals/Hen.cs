namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public class Hen : Livestock, IEatBerries, IBuyable, IStorable, IMovable
    {
        private static char[,] image = new char[,] { { '⌠' } };
        public Hen(MatrixCoords topLeft) : base(topLeft, image)
        {
        }

        public void EatBerry()
        {
            throw new NotImplementedException();
        }
    }
}
