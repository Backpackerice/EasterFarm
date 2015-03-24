namespace EasterFarm.Models.PresentFactory
{
    using System.Collections.Generic;

    using EasterFarm.Common;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.Market;

    public class Present : ISellable
    {
        private const int NeededBaskets = 1;
        private readonly Dictionary<IngredientType, int> neededIngredients;

        private int value;
        private MarketCurrency currency;
        private PresentType presentType;
        private FarmManager producer;

        public Present(PresentType presentType, int value, MarketCurrency currency, FarmManager producer, Dictionary<IngredientType, int> ingredients)
        {
            this.PresentType = presentType;
            this.Value = value;
            this.Currency = currency;
            this.Producer = producer;
            this.neededIngredients = new Dictionary<IngredientType, int>(ingredients);
            this.Make();
        }

        public int Value
        {
            get
            {
                return this.value;
            }

            internal set
            {
                this.value = value;
            }
        }

        public MarketCurrency Currency
        {
            get
            {
                return this.currency;
            }

            internal set
            {
                this.currency = value;
            }
        }

        public PresentType PresentType
        {
            get
            {
                return this.presentType;
            }

            internal set
            {
                this.presentType = value;
            }
        }

        public FarmManager Producer
        {
            get
            {
                return this.producer;
            }

            internal set
            {
                this.producer = value;
            }
        }

        public Dictionary<IngredientType, int> NeededIngredients
        {
            get
            {
                return this.neededIngredients;
            }
        }

        public void Make()
        {
            foreach (var ingredient in this.NeededIngredients)
            {
                if (this.Producer.Inventory.ContainsKey(ingredient.Key) && this.Producer.Inventory[ingredient.Key] >= ingredient.Value)
                {
                    this.Producer.Inventory[ingredient.Key] -= ingredient.Value;
                }
                else
                {
                    throw new InsufficientAmmountException(string.Empty, ingredient.Key.ToString());
                }
            }
        }
    }
}
