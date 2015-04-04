using EasterFarm.Models.FarmObjects.Byproducts;

namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;
    using EasterFarm.Models.FarmObjects.Food;

    public abstract class Livestock : Animal, IStorable, IMovable, IProduce
    {
        private Enum type;

        protected Livestock(MatrixCoords topLeft, Enum type)
            : base(topLeft)
        {
            this.Type = type;
            this.HasProduct = false;
        }

        public bool HasProduct { get; protected set; }


        public Enum Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                this.type = value;
            }
        }

        public abstract Livestock Clone();

        public abstract Byproduct Produce(ByproductColor color);
    }
}