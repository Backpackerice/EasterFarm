namespace EasterFarm.Console
{
    using EasterFarm.Common;
    using EasterFarm.GameLogic.Contracts;
    using EasterFarm.Models;
    using EasterFarm.Models.Contracts;

    public class Aim : IAim, IRenderable
    {
        private const int step = 3;
        private const int size = 3;
        private static Aim instance;

        private Aim()
        {
            this.TopLeft = new MatrixCoords(
                (Constants.WorldRows / 2) - 1,
                (int)((Constants.WorldCols * Constants.LeftRightScreenRatio / 2) - 1));
        }

        public static Aim Instance
        {
            get { return instance ?? (instance = new Aim()); }
        }

        public MatrixCoords TopLeft { get; private set; }

        public int Size { get { return size;} }

        public void MoveUp()
        {
            if (this.TopLeft.Row <= size)
            {
                this.TopLeft = new MatrixCoords(1, this.TopLeft.Col);
            }
            else
            {
                this.TopLeft = new MatrixCoords(this.TopLeft.Row - step, this.TopLeft.Col);
            }
        }

        public void MoveDown()
        {
            if (this.TopLeft.Row >= Constants.WorldRows - 1 - (2 * size))
            {
                this.TopLeft = new MatrixCoords(Constants.WorldRows - 1 - size, this.TopLeft.Col);
            }
            else
            {
                this.TopLeft = new MatrixCoords(this.TopLeft.Row + step, this.TopLeft.Col);
            }
        }

        public void MoveLeft()
        {
            if (this.TopLeft.Col <= size)
            {
                this.TopLeft = new MatrixCoords(this.TopLeft.Row, 1);
            }
            else
            {
                this.TopLeft = new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col - step);
            }
        }

        public void MoveRight()
        {
            if (this.TopLeft.Col >= (Constants.WorldCols * Constants.LeftRightScreenRatio) - (2 * size))
            {
                this.TopLeft = new MatrixCoords(
                    this.TopLeft.Row,
                    (int)(Constants.WorldCols * Constants.LeftRightScreenRatio) - size);
            }
            else
            {
                this.TopLeft = new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col + step);
            }
        }
    }
}
