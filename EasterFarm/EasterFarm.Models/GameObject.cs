namespace EasterFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public abstract class GameObject : IRenderable
    {
        protected GameObject(MatrixCoords topLeft)
        {
            this.TopLeft = topLeft;
            this.IsDestroyed = false;
        }

        public MatrixCoords TopLeft { get; protected set; }

        public bool IsDestroyed { get; set; }

        public override bool Equals(object obj)
        {
            var gameObject = obj as GameObject;
            return this.GetType() == gameObject.GetType() || this.GetType().IsSubclassOf(typeof(GameObject));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
