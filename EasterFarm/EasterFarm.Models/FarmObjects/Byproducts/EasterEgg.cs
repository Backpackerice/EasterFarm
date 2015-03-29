namespace EasterFarm.Models.FarmObjects.Byproducts
{
    using EasterFarm.Models.Contracts;

    public class EasterEgg : Egg, ICookable, IStorable
    {
        private EggColor color;

        public EasterEgg(MatrixCoords topLeft, EggColor color) 
            : base(topLeft)
        {
            this.Color = color;
            this.Type = ByproductType.EasterEgg;
        }

        public EggColor Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }
    }
}
