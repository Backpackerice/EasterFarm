namespace EasterFarm.Models.PresentFactory
{
    using System.Collections.Generic;

    using EasterFarm.Common;
    using EasterFarm.Models.Market;

    public abstract class PresentBuilder
    {
        private const int BasketAmmount = 1;

        public Present Present { get; set; }

        public Dictionary<IngredientType, int> Inventory
        {
            get
            {
                return Present.Producer.Inventory;
            }
        }

        public abstract void AddEggs();

        public abstract void AddFlour();

        public abstract void AddCocoa();

        public abstract void AddMilk();

        public abstract void AddRibbon();

        public void AddBAsket()
        {
            AddIngredient(IngredientType.Basket, BasketAmmount);
        }

        protected void AddIngredient(IngredientType ingredient, int ammount)
        {
            if (this.Inventory.ContainsKey(ingredient) && this.Inventory[ingredient] >= ammount)
            {
                Present.Producer.Inventory[ingredient] -= ammount;
            }
            else
            {
                throw new InsufficientAmmountException(string.Empty, ingredient.ToString());
            }
        }
    }
}
