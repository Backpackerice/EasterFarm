namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public class Lamb : Livestock, IEatBerries, IStorable, IMovable
    {
        public Lamb(MatrixCoords topLeft, char[,] image) 
            : base(topLeft, image)
        {
        }

        public override Livestock Clone()
        {
            Lamb original = this;
            Lamb newLamb = new Lamb(this.TopLeft, new char[0, 0]);

            return newLamb;
        }
    }
}
