namespace EasterFarm.Models.MarketPlace
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EasterFarm.Common;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Food;

    public sealed class Market
    {
        private ICollection<IBuyable> buyableProducts;

        public Market()
        {
            this.buyableProducts = new HashSet<IBuyable>();
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
        public int CalculateCost(ITradeable product, int quantity)
        {
            return product.Price * quantity;
        }

        public override string ToString()
        {
            return "Market";
        }
    }
}
