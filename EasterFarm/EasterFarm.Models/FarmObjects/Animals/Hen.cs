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
        public Hen(MatrixCoords topLeft, char[,] image) : base(topLeft, image)
        {
        }

        public void EatBerry()
        {
            throw new NotImplementedException();
        }
    }
}
