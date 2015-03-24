namespace EasterFarm.Models.Farm.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Fox : Villain
    {
        public Fox(MatrixCoords topLeft, char[,] image) : base(topLeft, image)
        {
        }
    }
}
