using EasterFarm.Models.FarmObjects.Byproducts;

namespace EasterFarm.Models.FarmObjects.Animals
{
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;

    public class Rabbit : Livestock, ICollectBerries, IStorable
    {
        public Rabbit(MatrixCoords topLeft)
            : base(topLeft, LivestockType.Rabbit)
        {
        }

        public override Livestock Clone()
        {
            Rabbit newRabbit = new Rabbit(this.TopLeft);

            return newRabbit;
        }

        public override Byproduct Produce(ByproductColor color)
        {
            return new TrophyEgg(this.TopLeft, color);
        }
    }
}
