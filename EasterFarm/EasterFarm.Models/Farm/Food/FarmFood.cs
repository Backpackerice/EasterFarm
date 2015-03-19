namespace EasterFarm.Models.Farm.Food
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class FarmFood : GameObject
    {
        public bool IsSpoilt { get; set; }
    }
}
