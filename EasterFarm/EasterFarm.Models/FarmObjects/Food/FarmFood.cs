namespace EasterFarm.Models.FarmObjects.Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;

    public abstract class FarmFood : GameObject, IStorable
    {
        private Enum type;
        private bool isSpoilt;

        protected FarmFood(MatrixCoords topLeft, bool isSpoiled) 
            : base(topLeft)
        {
            this.IsSpoilt = isSpoiled;
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
    }
}
