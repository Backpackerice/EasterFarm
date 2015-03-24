namespace EasterFarm.Models.FarmObjects.Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class FarmFood : GameObject
    {
        protected FarmFood(MatrixCoords topLeft, char[,] image, bool isSpoiled) : base(topLeft, image)
        {
            this.IsSpoilt = isSpoiled;
        }

        public bool IsSpoilt { get; private set; }
    }
}
