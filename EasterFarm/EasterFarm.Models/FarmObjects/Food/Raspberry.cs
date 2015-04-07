namespace EasterFarm.Models.FarmObjects.Food
{
    using EasterFarm.Models.FarmObjects.Byproducts;

    public class Raspberry : FarmFood
    {
        public Raspberry()
            : this(new MatrixCoords())
        {
        }

        public Raspberry(MatrixCoords topLeft)
            : base(topLeft, FarmFoodType.Raspberry)
        {
        }

        public override ByproductColor GetColor()
        {
            return ByproductColor.Red;
        }
    }
}
