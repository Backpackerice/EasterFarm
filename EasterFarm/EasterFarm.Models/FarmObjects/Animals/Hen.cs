namespace EasterFarm.Models.FarmObjects.Animals
{
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.MarketPlace;

    public class Hen : Livestock, IStorable
    {
        public Hen()
            : this(new MatrixCoords())
        {
        }

        public Hen(MatrixCoords topLeft)
            : base(topLeft, LivestockType.Hen)
        {
        }

        public override Livestock Clone()
        {
            Hen newHen = new Hen(this.TopLeft);

            return newHen;
        }

        public override Byproduct Produce(ByproductColor color)
        {
            return new EasterEgg(this.TopLeft, color);
        }
    }
}
