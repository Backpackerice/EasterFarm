namespace EasterFarm.Console
{
    using EasterFarm.Common;
    using EasterFarm.GameLogic.Contracts;
    using EasterFarm.Models;
    using EasterFarm.Models.Contracts;

    public class Aim : IAim, IRenderable
    {
        private const int Step = 3;
        private const int AimSize = 3;
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

        public int Size 
        { 
            get 
            { 
                return AimSize;
            } 
        }

        public void MoveUp()
        {
            if (this.TopLeft.Row <= AimSize)
            {
                this.TopLeft = new MatrixCoords(1, this.TopLeft.Col);
            }
            else
            {
                this.TopLeft = new MatrixCoords(this.TopLeft.Row - Step, this.TopLeft.Col);
            }
        }

        public void MoveDown()
        {
            if (this.TopLeft.Row >= Constants.WorldRows - 1 - (2 * AimSize))
            {
                this.TopLeft = new MatrixCoords(Constants.WorldRows - 1 - AimSize, this.TopLeft.Col);
            }
            else
            {
                this.TopLeft = new MatrixCoords(this.TopLeft.Row + Step, this.TopLeft.Col);
            }
        }

        public void MoveLeft()
        {
            if (this.TopLeft.Col <= AimSize)
            {
                this.TopLeft = new MatrixCoords(this.TopLeft.Row, 1);
            }
            else
            {
                this.TopLeft = new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col - Step);
            }
        }

        public void MoveRight()
        {
            if (this.TopLeft.Col >= (Constants.WorldCols * Constants.LeftRightScreenRatio) - (2 * AimSize))
            {
                this.TopLeft = new MatrixCoords(
                    this.TopLeft.Row,
                    (int)(Constants.WorldCols * Constants.LeftRightScreenRatio) - AimSize);
            }
            else
            {
                this.TopLeft = new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col + Step);
            }
        }
    }
}
