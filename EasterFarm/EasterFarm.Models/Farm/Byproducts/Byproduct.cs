namespace EasterFarm.Models.Farm.Byproducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public abstract class Byproduct : GameObject, ICookable
    {
        protected Byproduct(MatrixCoords topLeft, char[,] image) : base(topLeft, image)
        {
        }
    }
}
