namespace EasterFarm.Models.FarmObjects.Animals
{
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;
    using EasterFarm.Models.FarmObjects.Byproducts;

    public class Hen : Livestock, IEatBerries, IStorable
    {
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
            return new Egg(this.TopLeft);
        }
    }
}
