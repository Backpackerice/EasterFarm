namespace EasterFarm.Models.FarmObjects.Byproducts
{
    using EasterFarm.Models.Contracts;

    public class EasterEgg : Egg, ICookable, IStorable
    {
        private ByproductColor color;

        public EasterEgg(MatrixCoords topLeft, ByproductColor color) 
            : base(topLeft)
        {
            this.Color = color;
            this.Type = ByproductType.EasterEgg;
        }

        public ByproductColor Color
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
