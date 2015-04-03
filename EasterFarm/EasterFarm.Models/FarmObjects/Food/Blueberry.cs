namespace EasterFarm.Models.FarmObjects.Food
{
    using EasterFarm.Models.FarmObjects.Byproducts;

    public class Blueberry : FarmFood
    {
        public Blueberry(MatrixCoords topLeft) 
            : base(topLeft, FarmFoodType.Blueberry)
        {
        }

        public override ByproductColor GetColor()
        {
            return ByproductColor.Blue;
        }
    }
}
