namespace EasterFarm.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.GameLogic.Contracts;
    using EasterFarm.Models;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Animals;
    using EasterFarm.Models.FarmObjects.Food;

    public class ConsoleRenderer : IRenderer
    {
        private readonly Dictionary<Type, char[,]> images = new Dictionary<Type, char[,]>
        {
            { typeof(Hen), new char[,] { { '⌠' } } },
            { typeof(Fox), new char[,] { { '¥' } } },
            { typeof(Lamb), new char[,]  { {'π'} } },
            { typeof(Rabbit), new char[,] { { '╓' } } },
            { typeof(Wolf), new char[,] { {'╪'} } },
            { typeof(Blueberry), new char[,] { { '♠' } } },
            { typeof(Raspberry), new char[,] { { '♣' } } },
            { typeof(ScreenFrame), ScreenFrame.Instance.Image }
        };

        private int worldRows;
        private int worldCols;
        private char[,] renderMatrix;

        public ConsoleRenderer(int worldRows, int worldCols)
        {
            this.WorldRows = worldRows;
            this.WorldCols = worldCols;

            this.renderMatrix = new char[this.WorldRows, this.WorldCols];

            this.ClearRenderer();
        }

        private int WorldRows
        {
            get
            {
                return this.worldRows;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value worldRows cannot be negative.");
                }

                this.worldRows = value;
            }
        }

        private int WorldCols
        {
            get
            {
                return this.worldCols;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The value worldCols cannot be negative.");
                }

                this.worldCols = value;
            }
        }

        public void EnqueueForRendering(IRenderable obj)
        {
            char[,] objImage = images[obj.GetType()];

            int imageRows = objImage.GetLength(0);
            int imageCols = objImage.GetLength(1);

            MatrixCoords objTopLeft = obj.TopLeft;

            int lastRow = Math.Min(objTopLeft.Row + imageRows, this.WorldRows);
            int lastCol = Math.Min(objTopLeft.Col + imageCols, this.WorldCols);

            for (int row = obj.TopLeft.Row; row < lastRow; row++)
            {
                for (int col = obj.TopLeft.Col; col < lastCol; col++)
                {
                    if (row >= 0 && col >= 0)
                    {
                        this.renderMatrix[row, col] = objImage[row - obj.TopLeft.Row, col - obj.TopLeft.Col];
                    }
                }
            }
        }

        public void RenderAll()
        {
            Console.SetCursorPosition(0, 0);

            StringBuilder scene = new StringBuilder();

            for (int row = 0; row < this.WorldRows; row++)
            {
                for (int col = 0; col < this.WorldCols; col++)
                {
                    scene.Append(this.renderMatrix[row, col]);
                }
            }

            Console.Write(scene.ToString());
        }

        public void ClearRenderer()
        {
            for (int row = 0; row < this.WorldRows; row++)
            {
                for (int col = 0; col < this.WorldCols; col++)
                {
                    this.renderMatrix[row, col] = ' ';
                }
            }
        }
    }
}
