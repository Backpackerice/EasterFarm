namespace EasterFarm.Models.FarmObjects.Food
{
    using System;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Byproducts;

    public abstract class FarmFood : GameObject, IStorable
    {
        private Enum type;

        protected FarmFood(MatrixCoords topLeft, Enum type)
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

            private set
            {
                this.type = value;
            }
        }

        public abstract ByproductColor GetColor();
    }
}
