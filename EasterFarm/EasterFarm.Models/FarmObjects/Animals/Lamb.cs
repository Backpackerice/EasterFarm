namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.FarmObjects.Food;

    public class Lamb : Livestock, IEatBerries, IStorable, IMovable
    {
        private bool hasMilk;

        public Lamb(MatrixCoords topLeft)
            : base(topLeft, LivestockType.Lamb)
        {
            this.HasMilk = false;
        }

        public bool HasMilk
        {
            get
            {
                return this.hasMilk;
            }

            private set
            {
                this.hasMilk = value;
            }
        }

        public override void HandleBerry(FarmFood berry)
        {
            berry.IsDestroyed = true;

            if (!berry.IsSpoilt)
            {
                this.HasMilk = true;
            }
        }

        public Milk ProduceMilk()
        {
            return new Milk(this.TopLeft);
        }

        public override Livestock Clone()
        {
            Lamb original = this;
            Lamb newLamb = new Lamb(this.TopLeft);

            return newLamb;
        }
    }
}
