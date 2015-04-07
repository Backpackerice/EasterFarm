namespace EasterFarm.Console
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using EasterFarm.GameLogic.Contracts;
    using EasterFarm.Models;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Animals;
    using EasterFarm.Models.FarmObjects.Food;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.Presents;
using EasterFarm.Models.MarketPlace;

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
            { typeof(Egg), new char[,] {{'#'}}},
            { typeof(TrophyEgg), new char[,] {{'#'}}},
            { typeof(EasterEgg), new char[,] {{'#'}}},
            { typeof(Milk), new char[,] {{'#'}}},
            { typeof(Villain), new char[,] {{'#'}}},
        };
        //Added default symbol # because we dont yet know what symbols we are gonna use for the classes.

        private int worldRows;
        private int worldCols;
        private readonly char[,] renderMatrix;
        private readonly ConsoleFrame frame = ConsoleFrame.Instance;

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

            //Render Market
            Console.SetCursorPosition(55, 2);
            int i = 4;
            foreach (var product in marketProducts)
            {
                Console.WriteLine(product);
                Console.SetCursorPosition(55, i);
                i += 2;
            }
        }

        public void ClearRenderer()
        {
            for (int row = 0; row < this.WorldRows; row++)
            {
                for (int col = 0; col < this.WorldCols; col++)
                {
                    this.renderMatrix[row, col] = frame.Image[row, col];
                }
            }
        }

        //Market
        private readonly List<string> marketProducts = new List<string> 
        {
                "Flour 2" ,
                "Cocoa 4",     
                "Ribbon 8",        
                "Basket 12" ,
                "Rabbit 18"
        };

        public void RenderPresentFactory(IDictionary<IStorable, int> presents)
        {

        }
    }
}
