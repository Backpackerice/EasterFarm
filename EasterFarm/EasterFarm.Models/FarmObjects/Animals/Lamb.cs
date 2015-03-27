namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;

    public class Lamb : Livestock, IEatBerries, IStorable, IMovable
    {
        private static char[,] image = new char[,] {{'π'}};
        public Lamb(MatrixCoords topLeft, Enum type)
            : base(topLeft, LivestockType.Lamb)
        {
        }

        public override Livestock Clone()
        {
            Lamb original = this;
            Lamb newLamb = new Lamb(this.TopLeft, LivestockType.Lamb);

            return newLamb;
        }
    }
}
