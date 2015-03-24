namespace EasterFarm.Models.Farm.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Villain : GameObject
    {
        protected Villain(MatrixCoords topLeft, char[,] image) : base(topLeft, image)
        {
        }
    }
}
