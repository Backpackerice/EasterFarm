namespace EasterFarm.Models.FarmObjects.Food
{
    using EasterFarm.Models.FarmObjects.Byproducts;

    public class Raspberry : FarmFood
    {
        public Raspberry(MatrixCoords topLeft, bool isSpoiled) 
            : base(topLeft, FarmFoodType.Raspberry, isSpoiled)
        {
        }

        public override EggColor GetEggColor()
        {
            return EggColor.Red;
        }
    }
}
