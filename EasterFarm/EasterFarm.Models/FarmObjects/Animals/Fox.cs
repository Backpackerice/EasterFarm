﻿namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public class Fox : Villain, IMovable
    {
        private static char[,] image = new char[,] { { '¥' } };
        public Fox(MatrixCoords topLeft) : base(topLeft, image)
        {
        }
    }
}
