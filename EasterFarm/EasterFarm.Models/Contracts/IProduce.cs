using EasterFarm.Models.FarmObjects.Food;

namespace EasterFarm.Models.Contracts
{
    using EasterFarm.Models.FarmObjects.Byproducts;

    interface IProduce
    {
        bool HasProduct { get; }
        Byproduct Produce(ByproductColor color);
    }
}
