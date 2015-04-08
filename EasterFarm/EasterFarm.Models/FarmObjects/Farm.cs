namespace EasterFarm.Models
{
    using System.Collections.Generic;

    using EasterFarm.Models.FarmObjects.Animals;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.FarmObjects.Food;

    public class Farm
    {
        private HashSet<Livestock> livestocks;

        private HashSet<FarmFood> farmFoods;

        private HashSet<Villain> villains;

        private HashSet<Byproduct> byproducts;

        public Farm()
        {
            this.byproducts = new HashSet<Byproduct>();
            this.farmFoods = new HashSet<FarmFood>();
            this.villains = new HashSet<Villain>();
            this.livestocks = new HashSet<Livestock>();
        }

        public HashSet<Livestock> Livestocks
        {
            get
            {
                return this.livestocks;
            }
        }

        public HashSet<FarmFood> FarmFoods
        {
            get
            {
                return this.farmFoods;
            }
        }

        public HashSet<Villain> Villains
        {
            get
            {
                return this.villains;
            }
        }

        public HashSet<Byproduct> Byproducts
        {
            get
            {
                return this.byproducts;
            }
        }
    }
}
