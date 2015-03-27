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
        public Rabbit(MatrixCoords topLeft, char[,] image) 
            : base(topLeft, image)
        {
        }

        public override Livestock Clone()
        {
            Rabbit original = this;
            Rabbit newRabbit = new Rabbit(this.TopLeft, new char[0, 0]);

            return newRabbit;
        }
    }
}
