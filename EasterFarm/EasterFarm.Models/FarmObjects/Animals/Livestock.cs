namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;

    using EasterFarm.Models.Contracts;

    public abstract class Livestock : Animal, IStorable
    {
        private Enum type;

        protected Livestock(MatrixCoords topLeft, Enum type)
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

        public abstract Livestock Clone();
    }
}