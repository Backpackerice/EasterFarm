namespace EasterFarm.Models.FarmObjects.Byproducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public class EasterEgg : Egg, ICookable, IStorable
    {
        private EggColor color;

        public EasterEgg(MatrixCoords topLeft, char[,] image, EggColor color) 
            : base(topLeft, image)
        {
            this.Color = color;
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
