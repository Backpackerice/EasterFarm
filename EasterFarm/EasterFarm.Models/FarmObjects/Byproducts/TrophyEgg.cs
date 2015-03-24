namespace EasterFarm.Models.FarmObjects.Byproducts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TrophyEgg : EasterEgg
    {
        public TrophyEgg(MatrixCoords topLeft, char[,] image) : base(topLeft, image)
        {
        }
    }
}
