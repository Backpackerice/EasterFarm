namespace EasterFarm.Models
{
    using System;

    using EasterFarm.Models.Contracts;

    public class InventoryItem : IStorable
    {
        private Enum type;

        public InventoryItem(Enum type)
        {
            this.Type = type;
        }

        public Enum Type 
        {
            get
            {
                return this.type;
            }

            private set
            {
                this.type = value;
            }
        }
    }
}
