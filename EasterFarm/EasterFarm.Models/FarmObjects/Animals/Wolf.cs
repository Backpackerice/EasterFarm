namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Wolf : Villain
    {
        public Wolf(MatrixCoords topLeft, char[,] image) : base(topLeft, image)
        {
        }
    }
}
