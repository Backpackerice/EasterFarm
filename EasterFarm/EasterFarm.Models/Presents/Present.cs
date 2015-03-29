namespace EasterFarm.Models.Presents
{
    using System;
    using System.Collections.Generic;

    using EasterFarm.Common;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.MarketPlace;

    public class Present : ISellable, IStorable
    {
        private const int NeededBaskets = 1;
        private readonly Dictionary<Enum, int> ingredients;

        private int price;
        private Enum type;

        public Present(PresentType presentType, int price, Dictionary<Enum, int> ingredients)
        {
            this.Type = presentType;
            this.Price = price;
            this.ingredients = new Dictionary<Enum, int>(ingredients);
        }

        public int Price
        {
            get
            {
                return this.price;
            }

            internal set
            {
                this.price = value;
            }
        }

        public Enum Type
        {
            get
            {
                return this.type;
            }

            internal set
            {
                this.type = value;
            }
        }

        public Dictionary<Enum, int> Ingredients
        {
            get
            {
                return this.ingredients;
            }
        }
    }
}
