namespace EasterFarm.Models.FarmObjects.Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Blueberry : FarmFood
    {
        public Blueberry(MatrixCoords topLeft, char[,] image, bool isSpoiled) : base(topLeft, image, isSpoiled)
        {
        }
    }
}
