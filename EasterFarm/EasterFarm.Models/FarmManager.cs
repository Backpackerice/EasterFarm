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
    using EasterFarm.Models.FarmObjects;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.FarmObjects.Animals;

    // The player
    public class FarmManager
    {
        // TODO:
        // shoot villains
        // collect eggs
        // milks the lamb

        private Dictionary<IStorable, int> inventory;
        
        public FarmManager()
        {
            this.Inventory = new Dictionary<IStorable, int>();
        }

        public Dictionary<IStorable, int> Inventory
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

        public void GatherProduct(Dictionary<IStorable, int> Inventory, Byproduct product)
        {
            this.Inventory[product]++;
            product.IsDestroyed = true;
        }

        public void EvictVillain(Villain enemy)
        {
            enemy.IsDestroyed = true;
        }

        public Present MakePresent(PresentType presentType, PresentFactory presentFactory)
        {
            var present = presentFactory.Get(presentType);
            var ingredients = present.NeededIngredients;

            foreach (var ingredient in ingredients)
            {
                var igredient = this.Inventory.Keys.FirstOrDefault(p => p.Type == ingredient.Key);
                if (igredient != null && this.Inventory[igredient] >= ingredient.Value)
                {
                    this.Inventory[igredient] -= ingredient.Value;
                }
                else
                {
                    present = null;
                    throw new InsufficientAmmountException(string.Empty, ingredient.Key.ToString());
                }
            }

            return present;
        }

        public void AddToInventory(IStorable item)
        {
            this.Inventory.Add(item, 1);
        }
    }
}
