namespace EasterFarm.Models.FarmObjects.Animals
{
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.MarketPlace;

    public class Rabbit : Livestock, IStorable, IProduce
    {
        public Rabbit()
            : this(new MatrixCoords())
        {
        }

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
