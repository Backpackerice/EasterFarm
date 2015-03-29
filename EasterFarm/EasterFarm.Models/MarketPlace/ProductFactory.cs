namespace EasterFarm.Models.MarketPlace
{
    using System;

    using EasterFarm.Models.Contracts;

    public abstract class ProductFactory
    {
        public abstract IBuyable Get(Enum productType);
    }
}
