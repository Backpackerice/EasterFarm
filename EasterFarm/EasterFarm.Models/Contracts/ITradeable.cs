namespace EasterFarm.Models.Contracts
{
    using EasterFarm.Models.MarketPlace;

    public interface ITradeable : IStorable
    {
        CurrencyType Currency { get; }

        int Price { get; }
    }
}
