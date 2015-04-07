namespace EasterFarm.Models.FarmObjects.Byproducts
{
    using EasterFarm.Models.Contracts;

    public class EasterEgg : Egg, ICookable, IStorable
    {
        private ByproductColor color;

        public EasterEgg(ByproductColor color)
            : this(new MatrixCoords(), color)
        {
        }

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

        public override bool Equals(object obj)
        {
            var gameObject = obj as EasterEgg;
            return this.GetType() == gameObject.GetType() || this.GetType().IsSubclassOf(typeof(GameObject));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
