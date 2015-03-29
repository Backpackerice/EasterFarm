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
        private static Market marketInstance;
        private ICollection<IBuyable> buyableProducts;

        private Market()
        {
            this.buyableProducts = new HashSet<IBuyable>();
        }

        public static Market Instance
        {
            get
            {
                if (marketInstance == null)
                {
                    marketInstance = new Market();
                }

                return marketInstance;
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
