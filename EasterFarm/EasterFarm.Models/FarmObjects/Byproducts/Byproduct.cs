namespace EasterFarm.Models.FarmObjects.Byproducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public abstract class Byproduct : GameObject, ICookable, IStorable
    {
        protected Byproduct(MatrixCoords topLeft) 
            : base(topLeft)
        {
        }

        public Enum Type
        {
            get { throw new NotImplementedException(); }
        }
    }
}
