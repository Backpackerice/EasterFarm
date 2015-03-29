namespace EasterFarm.Models.FarmObjects.Food
{
    using EasterFarm.Models.FarmObjects.Byproducts;

    public class Blueberry : FarmFood
    {
        public Blueberry(MatrixCoords topLeft, bool isSpoiled) 
            : base(topLeft, FarmFoodType.Blueberry, isSpoiled)
        {
        }

        public override EggColor GetEggColor()
        {
            return EggColor.Blue;
        }
    }
}
