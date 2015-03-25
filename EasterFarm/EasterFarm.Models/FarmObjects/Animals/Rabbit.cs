namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public class Rabbit : Livestock, IEatBerries, ICookable
    {
        public Rabbit(MatrixCoords topLeft, char[,] image) : base(topLeft, image)
        {
        }
    }
}
