namespace EasterFarm.Models.FarmObjects.Animals
{
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;
    using EasterFarm.Models.FarmObjects.Byproducts;

    public class Lamb : Livestock, IEatBerries, IStorable
    {
        public Lamb(MatrixCoords topLeft)
            : base(topLeft, LivestockType.Lamb)
        {
        }

        public override Livestock Clone()
        {
            Lamb newLamb = new Lamb(this.TopLeft);

            return newLamb;
        }

        public override Byproduct Produce(ByproductColor color)
        {
            return new Milk(this.TopLeft);
        }
    }
}
