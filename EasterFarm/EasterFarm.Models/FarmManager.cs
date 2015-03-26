namespace EasterFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Common;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;
    using EasterFarm.Models.Presents;
    using EasterFarm.Models.FarmObjects.Food;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.FarmObjects.Animals;

    // The player
    public class FarmManager
    {
        // TODO:
        // shoot villains
        // collect eggs
        // milks the lamb

        private const string NoItemInInventoryExcMsg = "No such item in inventory: ";

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

        public void AddToInventory(IStorable item)
        {
            if (this.Inventory.ContainsKey(item))
            {
                this.Inventory[item] += 1;
            }
            else
            {
                this.Inventory.Add(item, 1);
            }
        }

        public void AddMultipleToInventory(IStorable item, int quantity)
        {
            if (this.Inventory.ContainsKey(item))
            {
                this.Inventory[item] += quantity;
            }
            else
            {
                this.Inventory.Add(item, quantity);
            }
        }

        public void RemoveFromInventory(IStorable item)
        {
            if (this.InventoryContains(item))
            {
                this.Inventory.Remove(item);
            }
            else
            {
                throw new InsufficientAmmountException(NoItemInInventoryExcMsg, item.ToString());
            }
        }

        public void SubtractFromInventoryItem(IStorable item, int quantity)
        {
            if (this.InventoryContains(item) && this.Inventory[item] >= quantity)
            {
                this.Inventory[item] -= quantity;
            }
            else
            {
                throw new InsufficientAmmountException(string.Empty, item.ToString());
            }
        }

        public bool InventoryContains(IStorable item)
        {
            return this.Inventory.ContainsKey(item) ? true : false;
        }

        public IStorable GetFromInventoryByType(Enum type)
        {
            return this.Inventory.FirstOrDefault(x => x.Key.Type == type).Key;
        }
    }
}
