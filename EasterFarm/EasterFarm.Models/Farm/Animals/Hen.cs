namespace EasterFarm.Models.Farm.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public class Hen : Livestock, ICollectBerries
    {
        public Hen(MatrixCoords topLeft, char[,] image) : base(topLeft, image)
        {
        }
    }
}
