namespace EasterFarm.Models
{
    using EasterFarm.Models.Market;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    // The player
    public class FarmManager
    {
        // TODO:
        // clears rocks
        // shoot villains
        // collect eggs
        // milks the lamb

        private Dictionary<IngredientType, int> inventory;
        
        public FarmManager()
        {
            this.Inventory = new Dictionary<IngredientType, int>();
        }

        public Dictionary<IngredientType, int> Inventory
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
    }
}
