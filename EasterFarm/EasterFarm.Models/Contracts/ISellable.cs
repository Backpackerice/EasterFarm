namespace EasterFarm.Models.Contracts
{
    public interface ISellable : IProduct
    {
        int Value { get; }
    }
}
