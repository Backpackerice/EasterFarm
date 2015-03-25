namespace EasterFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Common;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.Market;
    using EasterFarm.Models.Presents;

    // The player
    public class FarmManager
    {
        // TODO:
        // clears rocks
        // shoot villains
        // collect eggs
        // milks the lamb

        private Dictionary<Enum, int> inventory;
        
        public FarmManager()
        {
            this.Inventory = new Dictionary<Enum, int>();
        }

        public Dictionary<Enum, int> Inventory
        {
            get
            {
                return this.inventory;
            }

            set
            {
                this.inventory = value;
            }
        }

        public void MakePresent(PresentType presentType, Dictionary<Enum, int> ingredients, PresentFactory presentFactory)
        {
            foreach (var ingredient in ingredients)
            {
                if (this.Inventory.ContainsKey(ingredient.Key) && this.Inventory[ingredient.Key] >= ingredient.Value)
                {
                    this.Inventory[ingredient.Key] -= ingredient.Value;
                }
                else
                {
                    throw new InsufficientAmmountException(string.Empty, ingredient.Key.ToString());
                }
            }

            presentFactory.Get(presentType);
            this.AddToInventory(presentType);
        }

        public void AddToInventory(Enum type)
        {
            this.Inventory.Add(type, 1);
        }
    }
}
