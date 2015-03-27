namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Food;

    public class Hen : Livestock, IEatBerries, IStorable, IMovable
    {
        public Hen(MatrixCoords topLeft, char[,] image) 
            : base(topLeft, image)
        {
        }

        public override Livestock Clone()
        {
            Hen original = this;
            Hen newHen = new Hen(this.TopLeft, new char[0,0]);

            return newHen;
        }
    }
}
