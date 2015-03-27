namespace EasterFarm.Models.FarmObjects.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models.Contracts;

    public abstract class MovingObject : GameObject, IMovable
    {
        protected MovingObject(MatrixCoords topLeft) 
            : base(topLeft)
        {
        }

        public void Move(int[,] map)
        {
            int mapHeight = map.GetLength(0);
            int mapWidth = map.GetLength(1);
            int currentRow = this.TopLeft.Row;
            int currentCol = this.TopLeft.Col;

            for (int row = (currentRow - 1 > 0 ? currentRow - 1 : 0); row <= (currentRow + 1 <= mapHeight - 1 ? currentRow + 1 : mapHeight - 1); row++)
            {
                for (int col = (currentCol - 1 > 0 ? currentCol - 1 : 0); col <= (currentCol + 1 <= mapWidth - 1 ? currentCol + 1 : mapWidth - 1); col++)
                {
                    if (map[row,col] < map[currentRow,currentCol])
                    {
                        this.TopLeft = new MatrixCoords(row, col);
                        map[row, col] = int.MaxValue;
                        return;
                    }
                }
            }

            map[currentRow, currentCol] = int.MaxValue;
        }
    }
}
