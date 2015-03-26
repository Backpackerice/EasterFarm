namespace EasterFarm.Models.Contracts
{
    using EasterFarm.Models.MarketPlace;

    public interface ITradeable : IStorable
    {
        int Price { get; }
    }
}
