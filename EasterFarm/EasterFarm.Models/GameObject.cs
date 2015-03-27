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
        private MatrixCoords topLeft;
        private char[,] image;

        protected GameObject(MatrixCoords topLeft)
        {
            this.topLeft = topLeft;
            this.IsDestroyed = false;
        }

        public MatrixCoords TopLeft
        {
            get { return this.topLeft; }
            protected set { this.topLeft = value; }
        }

        public char[,] Image
        {
            get { return this.image; }
            protected set { this.image = value; }
        }

        public bool IsDestroyed { get; set; }
    }
}
