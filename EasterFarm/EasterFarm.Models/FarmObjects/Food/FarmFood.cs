namespace EasterFarm.Models.FarmObjects.Food
{
    using System;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Byproducts;

    public abstract class FarmFood : GameObject, IStorable
    {
        private Enum type;
        private bool isSpoilt;

        protected FarmFood(MatrixCoords topLeft, Enum type, bool isSpoiled)
            : base(topLeft)
        {
            this.IsSpoilt = isSpoiled;
            this.Type = type;
        }

        public bool IsSpoilt
        {
            get
            {
                return this.isSpoilt;
            }

            private set
            {
                this.isSpoilt = value;
            }
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

        public abstract EggColor GetEggColor();
    }
}
