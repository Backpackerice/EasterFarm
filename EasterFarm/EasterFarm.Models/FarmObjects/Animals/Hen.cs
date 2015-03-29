namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Food;
    using EasterFarm.Models.MarketPlace;
    using EasterFarm.Models.FarmObjects.Byproducts;

    public class Hen : Livestock, IEatBerries, IStorable, IMovable
    {
        private bool hasEgg;

        public Hen(MatrixCoords topLeft)
            : base(topLeft, LivestockType.Hen)
        {
            this.HasEgg = false;
        }

        public bool HasEgg
        {
            get
            {
                return this.hasEgg;
            }

            private set
            {
                this.hasEgg = value;
            }
        }

        // TODO: move to engine?
        public override void HandleBerry(FarmFood berry)
        {
            berry.IsDestroyed = true;

            if (!berry.IsSpoilt)
            {
                this.HasEgg = true;
            }
        }

        public Egg LayEgg(EggColor color)
        {          
            this.HasEgg = false;

            return new EasterEgg(this.TopLeft, color);
        }

        public override Livestock Clone()
        {
            Hen original = this;
            Hen newHen = new Hen(this.TopLeft);

            return newHen;
        }
    }
}
