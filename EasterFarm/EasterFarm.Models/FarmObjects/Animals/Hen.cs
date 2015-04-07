namespace EasterFarm.Models.FarmObjects.Animals
{
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;
    using EasterFarm.Models.FarmObjects.Byproducts;

    public class Hen : Livestock, IEatBerries, IStorable
    {
        public Hen()
            : this(new MatrixCoords())
        {
        }

        public Hen(MatrixCoords topLeft)
            : base(topLeft, LivestockType.Hen)
        {
            //this.HasProduct = false;
        }

        public override Livestock Clone()
        {
            Hen newHen = new Hen(this.TopLeft);

            return newHen;
        }

        public override Byproduct Produce(ByproductColor color)
        {
            //this.HasProduct = false;
            return new EasterEgg(this.TopLeft, color);
        }
    }
}
