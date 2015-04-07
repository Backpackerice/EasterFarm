namespace EasterFarm.Models.FarmObjects.Animals
{
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.MarketPlace;

    public class Lamb : Livestock, IStorable
    {
        public Lamb()
            : this(new MatrixCoords())
        {
        }

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
