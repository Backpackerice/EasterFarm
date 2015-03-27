﻿namespace EasterFarm.Models.FarmObjects.Byproducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public class Milk : Byproduct, ICookable, IStorable
    {
        public Milk(MatrixCoords topLeft) 
            : base(topLeft)
        {
        }
    }
}
