namespace EasterFarm.Models.FarmObjects.Byproducts
{
    using EasterFarm.Models.Contracts;

    public class Egg : Byproduct, ICookable, IStorable
    {
        public Egg(MatrixCoords topLeft) 
            : base(topLeft, ByproductType.PlainEgg)
        {
        }
    }
}
