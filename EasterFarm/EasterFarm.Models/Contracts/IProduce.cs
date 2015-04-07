namespace EasterFarm.Models.Contracts
{
    using EasterFarm.Models.FarmObjects.Byproducts;

    public interface IProduce
    {
        Byproduct Produce(ByproductColor color);
    }
}
