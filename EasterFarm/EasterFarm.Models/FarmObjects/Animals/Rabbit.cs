using EasterFarm.Models.FarmObjects.Byproducts;

namespace EasterFarm.Models.FarmObjects.Animals
{
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;

    public class Rabbit : Livestock, ICollectBerries, IStorable
    {
        public Rabbit()
            : this(new MatrixCoords())
        {
        }

        public Rabbit(MatrixCoords topLeft)
            : base(topLeft, LivestockType.Rabbit)
        {
            //this.HasProduct = false;
        }

        public override Livestock Clone()
        {
            Rabbit newRabbit = new Rabbit(this.TopLeft);

            return newRabbit;
        }

        public override Byproduct Produce(ByproductColor color)
        {
            //this.HasProduct = false;
            return new TrophyEgg(this.TopLeft, color);
        }
    }
}
