namespace EasterFarm.Console
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EasterFarm.Common;
    using EasterFarm.GameLogic.Contracts;
    using EasterFarm.Models;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Animals;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.FarmObjects.Food;

    public class ConsoleRenderer : IRenderer
    {
        private readonly Dictionary<Type, char[,]> images = new Dictionary<Type, char[,]>
        {
            // { typeof(Aim), new char[,]{{'┌', ' ', '┐'}, {' ', ' ', ' '}, {'└', ' ', '┘'}}},
            // { typeof(Hen), new char[,] { { '⌠' } } },
            // { typeof(Fox), new char[,] { { '¥' } } },
            // { typeof(Lamb), new char[,]  { {'π'} } },
            // { typeof(Rabbit), new char[,] { { '╓' } } },
            // { typeof(Wolf), new char[,] { {'╪'} } },
            // { typeof(Blueberry), new char[,] { { '♠' } } },
            // { typeof(Raspberry), new char[,] { { '♣' } } },
            // { typeof(Egg), new char[,] {{'#'}}},
            // { typeof(TrophyEgg), new char[,] {{'#'}}},
            // { typeof(EasterEgg), new char[,] {{'#'}}},
            // { typeof(Milk), new char[,] {{'#'}}},
            // { typeof(Villain), new char[,] {{'#'}}},
            { typeof(Aim), new char[,] { {'┌', ' ', '┐'}, {' ', ' ', ' '}, {'└', ' ', '┘'} } },
            { typeof(Hen), new char[,] { { '\\', '_', '/','^'} } },
            { typeof(Fox), new char[,] { { '/', '|', ' ' }, { '@', '@', '-' } } },
            { typeof(Lamb), new char[,] { {'-', '(', '_', ')', '-'}, {'(','_', '_', ')', ' '} } },
            { typeof(Rabbit), new char[,] { { ' ', '!', '!' }, { '*', '_', '"' } } },
            { typeof(Wolf), new char[,] { { '(', '\\', '_', ' ' }, { ' ', ' ', '"', '.' } } },
            { typeof(Blueberry), new char[,] { { '♠' } } },
            { typeof(Raspberry), new char[,] { { '♣' } } },
            { typeof(Egg), new char[,] { {'/', '^', '\\'}, {'\\', '_', '/'} } },
            { typeof(TrophyEgg), new char[,] { {'/', '^', '\\'}, {'\\', '@', '/'} } },
            { typeof(EasterEgg), new char[,] { {'/', '^', '\\'}, {'\\', '#', '/'} } },
            { typeof(Milk), new char[,] { {' ', '_', ' '}, {'|',' ', '|'}, {'(','_', ')'} } },
        };

        private readonly char[,] renderMatrix;
        private readonly ConsoleFrame frame = ConsoleFrame.Instance;

        private int worldRows;
        private int worldCols;

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
            char[,] objImage = this.images[obj.GetType()];

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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Green;
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
                    this.renderMatrix[row, col] = this.frame.Image[row, col];
                }
            }
        }

        public void RenderPresentFactory(IDictionary<IStorable, int> inventory)
        {
            HelperMethods.PrintOnPosition((int)(this.WorldCols * Constants.LeftRightScreenRatio) + 2, (int)(this.WorldRows * Constants.UpDownScreenRatio) + 1, new string('_', 45), ConsoleColor.Red);
            HelperMethods.PrintOnPosition((int)(this.WorldCols * Constants.LeftRightScreenRatio) + 20, (int)(this.WorldRows * Constants.UpDownScreenRatio) + 1, "INVENTORY", ConsoleColor.Red);

            int row = (int)(this.WorldRows * Constants.UpDownScreenRatio) + 3;
            int colItem = (int)(this.WorldCols * Constants.LeftRightScreenRatio) + 5;
            int colQuantity = (int)(this.WorldCols * Constants.LeftRightScreenRatio) + 20;
            foreach (var item in inventory.Keys)
            {
                HelperMethods.PrintOnPosition(colItem, row, item.Type.ToString(), ConsoleColor.Black);
                HelperMethods.PrintOnPosition(colQuantity, row, inventory[item].ToString(), ConsoleColor.Black);
                row++;

                if (row == (this.WorldRows - 2))
                {
                    row = (int)(this.WorldRows * Constants.UpDownScreenRatio) + 3;
                    colItem = (int)(this.WorldCols * Constants.LeftRightScreenRatio) + 25;
                    colQuantity = (int)(this.WorldCols * Constants.LeftRightScreenRatio) + 42;
                }
            }
        }

        public void RenderMarket(ICollection<IBuyable> products)
        {
            HelperMethods.PrintOnPosition((int)(this.WorldCols * Constants.LeftRightScreenRatio) + 2, 2, new string('_', 45), ConsoleColor.Red);
            HelperMethods.PrintOnPosition((int)(this.WorldCols * Constants.LeftRightScreenRatio) + 20, 2, "MARKET PLACE", ConsoleColor.Red);

            int row = 4;
            foreach (var product in products)
            {
                HelperMethods.PrintOnPosition((int)(this.WorldCols * Constants.LeftRightScreenRatio) + 5, row, product.Type.ToString(), ConsoleColor.Black);
                HelperMethods.PrintOnPosition((int)(this.WorldCols * Constants.LeftRightScreenRatio) + 40, row, product.Price.ToString() + " rbs", ConsoleColor.Black);
                row += 2;
            }
        }

        public void RenderGameOver()
        {
            Console.Clear();
            HelperMethods.PrintMatrix(Constants.GameOverMessage, 22, this.worldRows / 2 - 3, ConsoleColor.Black);
            Console.ReadKey();
        }
    }
}
