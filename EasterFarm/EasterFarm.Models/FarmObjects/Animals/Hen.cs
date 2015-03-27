namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Food;
    using EasterFarm.Models.MarketPlace;

    public class Hen : Livestock, IEatBerries, IStorable, IMovable
    {
        private static char[,] image = new char[,] { { '⌠' } };
        public Hen(MatrixCoords topLeft, Enum type) 
            : base(topLeft, LivestockType.Hen)
        {
        }

        public override Livestock Clone()
        {
            Hen original = this;
            Hen newHen = new Hen(this.TopLeft, LivestockType.Hen);

            return newHen;
        }
    }
}
