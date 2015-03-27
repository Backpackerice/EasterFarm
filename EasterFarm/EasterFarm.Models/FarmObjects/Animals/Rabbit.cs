namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;

    public class Rabbit : Livestock, ICollectBerries, IStorable, IMovable
    {
        private static char[,] image = new char[,] { { '╓' } };
        public Rabbit(MatrixCoords topLeft, Enum type)
            : base(topLeft, LivestockType.Rabbit)
        {
        }

        public override Livestock Clone()
        {
            Rabbit original = this;
            Rabbit newRabbit = new Rabbit(this.TopLeft, LivestockType.Rabbit);

            return newRabbit;
        }
    }
}
