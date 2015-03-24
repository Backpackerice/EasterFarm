﻿namespace EasterFarm.Models.Farm.Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Raspberry : FarmFood
    {
        public Raspberry(MatrixCoords topLeft, char[,] image, bool isSpoiled) : base(topLeft, image, isSpoiled)
        {
        }
    }
}
