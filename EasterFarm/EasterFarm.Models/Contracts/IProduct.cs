namespace EasterFarm.Models.Contracts
{
    using EasterFarm.Models.Market;

    public  interface IProduct
    {
       MarketCurrency Currency { get; }
    }
}
