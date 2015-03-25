namespace EasterFarm.Models.PresentFactory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.FarmObjects.Food;
using EasterFarm.Models.Market;

    public class EasterFood : Present
    {
        private FoodType foodType;
        private FarmManager producer;

        public EasterFood(FoodType foodType)
            : this(foodType, 0, MarketCurrency.Blueberries)
        {
        }

        public EasterFood(FoodType foodType, int value, MarketCurrency currency)
            : base(value, MarketCurrency.Blueberries)
        {
            this.FoodType = foodType;
            //TODO
            this.Producer = new FarmManager();
        }

        public FoodType FoodType
        {
            get
            {
                return this.foodType;
            }

            private set
            {
                this.foodType = value;
            }
        }

        public FarmManager Producer
        {
            get
            {
                return this.producer;
            }

            private set
            {
                this.producer = value;
            }
        }
    }
}
