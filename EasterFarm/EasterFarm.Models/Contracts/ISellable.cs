namespace EasterFarm.Models.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.FarmObjects.Food;
    using EasterFarm.Models.Market;

    public interface ISellable
    {
        int Value { get; }

        MarketCurrency Currency { get; }
    }
}
