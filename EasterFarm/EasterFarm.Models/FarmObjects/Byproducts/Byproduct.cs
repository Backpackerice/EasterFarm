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
        private Enum type;

        protected Byproduct(MatrixCoords topLeft, Enum type) 
            : base(topLeft)
        {
            this.Type = type;
        }

        public Enum Type
        {
            get
            {
                return this.type;
            }

            protected set
            {
                this.type = value;
            }
        }
    }
}
