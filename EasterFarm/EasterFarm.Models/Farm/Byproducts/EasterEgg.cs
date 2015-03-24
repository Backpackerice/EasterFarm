namespace EasterFarm.Models.Farm.Byproducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EasterEgg : Egg
    {
        public EasterEgg(MatrixCoords topLeft, char[,] image) : base(topLeft, image)
        {
        }
    }
}
