namespace EasterFarm.Models.FarmObjects.Byproducts
{
    using EasterFarm.Models.Contracts;

    public class Milk : Byproduct, ICookable, IStorable
    {
        public Milk(MatrixCoords topLeft) 
            : base(topLeft, ByproductType.Milk)
        {
        }
    }
}
