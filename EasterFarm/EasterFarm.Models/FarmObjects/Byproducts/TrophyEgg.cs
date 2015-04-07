namespace EasterFarm.Models.FarmObjects.Byproducts
{
    using EasterFarm.Models.Contracts;

    public class TrophyEgg : EasterEgg, ICookable, IStorable
    {
        public TrophyEgg(ByproductColor color)
            : this(new MatrixCoords(), color)
        {
        }

        public TrophyEgg(MatrixCoords topLeft, ByproductColor color) 
            : base(topLeft, color)
        {
            this.Type = ByproductType.TrophyEgg;
        }
    }
}
