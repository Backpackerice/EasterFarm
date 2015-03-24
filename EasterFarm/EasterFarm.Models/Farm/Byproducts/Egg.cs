namespace EasterFarm.Models.Farm.Byproducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public class Egg : Byproduct
    {
        public Egg(MatrixCoords topLeft, char[,] image) : base(topLeft, image)
        {
        }
    }
}
