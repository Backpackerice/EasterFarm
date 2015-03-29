namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;
    using EasterFarm.Models.FarmObjects.Food;

    public class Rabbit : Livestock, ICollectBerries, IStorable, IMovable
    {
        private static char[,] image = new char[,] { { '╓' } };
        public Rabbit(MatrixCoords topLeft)
            : base(topLeft, LivestockType.Rabbit)
        {
        }

        public override void HandleBerry(FarmFood berry)
        {
            berry.IsDestroyed = true;
        }

        public override Livestock Clone()
        {
            Rabbit original = this;
            Rabbit newRabbit = new Rabbit(this.TopLeft);

            return newRabbit;
        }
    }
}
