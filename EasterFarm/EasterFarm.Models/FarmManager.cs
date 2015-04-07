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

    public class FarmManager
    {
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

        public void GatherProduct(Byproduct product)
        {
            this.AddToInventory(product);
            product.IsDestroyed = true;
        }

        public void EvictVillain(Villain enemy)
        {
            enemy.IsDestroyed = true;
        }

        public void AddToInventory(IStorable item)
        {
            var storedItem = this.Inventory
                .FirstOrDefault(i => i.Key.Type.ToString() == item.Type.ToString())
                .Key;

            if (storedItem != null)
            {
                this.Inventory[storedItem] += 1;
            }
            else
            {
                this.Inventory.Add(item, 1);
            }
        }

        public void AddMultipleToInventory(IStorable item, int quantity)
        {
            var storedItem = this.Inventory
                           .FirstOrDefault(i => i.Key.Type.ToString() == item.Type.ToString())
                           .Key;

            if (storedItem != null)
            {
                this.Inventory[storedItem] += 1;
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
            var storedItem = this.Inventory
                           .FirstOrDefault(i => i.Key.Type.ToString() == item.Type.ToString())
                           .Key;

            if (storedItem != null && this.Inventory[item] >= quantity)
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
            var storedItem = this.Inventory
                        .FirstOrDefault(i => i.Key.Type.ToString() == item.Type.ToString())
                        .Key;

            return storedItem != null;
        }

        public IStorable GetFromInventoryByType(Enum type)
        {
            return this.Inventory.FirstOrDefault(x => x.Key.Type == type).Key;
        }

        public void MakePresent(PresentType presentType, PresentFactory presentFactory)
        {
            foreach (var ingredient in RecipeConstants.Recipes[presentType])
            {
                var item = this.GetFromInventoryByType(ingredient.Key);
                if (item != null)
                {
                    this.SubtractFromInventoryItem(item, ingredient.Value);
                }
                else
                {
                    throw new InsufficientAmmountException(ingredient.Key.ToString());
                }
            }

            var present = presentFactory.Get(presentType);
            this.AddToInventory(present);
        }

        public void BuyProducts(IBuyable product, int quantity, Market market)
        {
            int cost = market.CalculateCost(product, quantity);
            var currency = this.GetFromInventoryByType(FarmFoodType.Raspberry);

            if (currency != null && this.Inventory[currency] >= cost)
            {
                this.Inventory[currency] -= cost;
            }
            else
            {
                throw new InsufficientAmmountException(currency.ToString());
            }

            this.AddToInventory(product);
        }

        public void SellProducts(ISellable product, int quantity, Market market)
        {
            int income = market.CalculateCost(product, quantity);
            var currency = this.GetFromInventoryByType(FarmFoodType.Raspberry);

            this.RemoveFromInventory(product);
            this.AddMultipleToInventory(currency, income);
        }
    }
}
