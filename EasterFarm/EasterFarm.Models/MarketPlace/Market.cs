namespace EasterFarm.Models.MarketPlace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EasterFarm.Common;
    using EasterFarm.Models.Contracts;

    public class Market
    {
        private ICollection<IBuyable> buyableProducts;
        private FarmManager dealer;

        public Market(FarmManager dealer)
        {
            this.buyableProducts = new HashSet<IBuyable>();
            this.Dealer = dealer;
        }

        public FarmManager Dealer
        {
            get
            {
                return this.dealer;
            }

            private set
            {
                this.dealer = value;
            }
        }

        public ICollection<IBuyable> BuyableProducts
        {
            get
            {
                return this.buyableProducts;
            }
        }

        public void AddProduct(IBuyable product)
        {
            this.BuyableProducts.Add(product);
        }

        public void RemoveProduct(IBuyable product)
        {
            this.BuyableProducts.Remove(product);
        }

        public IBuyable FindProduct(Enum productType)
        {
            return this.BuyableProducts.FirstOrDefault(x => x.Type == productType);
        }

        public void BuyProducts(IBuyable product, int quantity)
        {
            int cost = this.CalculateCost(product, quantity);
            var currency = this.Dealer.GetCurrencyFromInventory(product.Currency);

            if (currency != null && this.Dealer.Inventory[currency] >= cost)
            {
                this.Dealer.Inventory[currency] -= cost;
            }
            else
            {
                throw new InsufficientAmmountException(currency.ToString());
            }

            this.Dealer.AddToInventory(product);
        }

        public void SellProducts(ISellable product, int quantity)
        {
            int income = this.CalculateCost(product, quantity);
            var currency = this.Dealer.GetCurrencyFromInventory(product.Currency);

            this.Dealer.RemoveFromInventory(product);
            this.Dealer.AddMultipleToInventory(currency, income);
        }

        public override string ToString()
        {
            return "Market";
        }

        private int CalculateCost(ITradeable product, int quantity)
        {
            return product.Price * quantity;
        }
    }
}
