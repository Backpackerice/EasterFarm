namespace EasterFarm.Console
{
    using EasterFarm.Common;

    // The ScreenFrame class implements the Singleton design pattern.
    internal sealed class ConsoleFrame
    {
        private static ConsoleFrame instance;

        private ConsoleFrame()
        {
            this.Image = GetScreenFrameImage();
        }

        public static ConsoleFrame Instance
        {
            get { return instance ?? (instance = new ConsoleFrame()); }
        }

        public char[,] Image { get; private set; }

        private static char[,] GetScreenFrameImage()
        {
            char[,] frame = new char[Constants.WorldRows, Constants.WorldCols];

            for (int row = 0; row < frame.GetLength(0); row++)
            {
                for (int col = 0; col < frame.GetLength(1); col++)
                {
                    if ((row == 0 || row == frame.GetLength(0) - 1) && (col > 0 && col < frame.GetLength(1) - 1) && col != (int)(Constants.LeftRightScreenRatio * frame.GetLength(1))
                        || row == (int)(Constants.UpDownScreenRatio * frame.GetLength(0)) && (col > (int)(Constants.LeftRightScreenRatio * frame.GetLength(1)) && col < frame.GetLength(1) - 1))
                    {
                        frame[row, col] = '═';
                    }
                    else if (row == 0 && col == 0)
                    {
                        frame[row, col] = '╔';
                    }
                    else if (row == 0 && col == frame.GetLength(1) - 1)
                    {
                        frame[row, col] = '╗';
                    }
                    else if (row == 0 && col == (int)(Constants.LeftRightScreenRatio * frame.GetLength(1)))
                    {
                        frame[row, col] = '╦';
                    }
                    else if (row == frame.GetLength(0) - 1 && col == (int)(Constants.LeftRightScreenRatio * frame.GetLength(1)))
                    {
                        frame[row, col] = '╩';
                    }
                    else if (row == frame.GetLength(0) - 1 && col == 0)
                    {
                        frame[row, col] = '╚';
                    }
                    else if (row == frame.GetLength(0) - 1 && col == frame.GetLength(1) - 1)
                    {
                        frame[row, col] = '╝';
                    }
                    else if (col == 0 || col == frame.GetLength(1) - 1 && row != (int)(Constants.UpDownScreenRatio * frame.GetLength(0))
                        || col == (int)(Constants.LeftRightScreenRatio * frame.GetLength(1)) && row != (int)(Constants.UpDownScreenRatio * frame.GetLength(0)))
                    {
                        frame[row, col] = '║';
                    }
                    else if (row == (int)(Constants.UpDownScreenRatio * frame.GetLength(0)) && col == (int)(Constants.LeftRightScreenRatio * frame.GetLength(1)))
                    {
                        frame[row, col] = '╠';
                    }
                    else if (row == (int)(Constants.UpDownScreenRatio * frame.GetLength(0)) && col == frame.GetLength(1) - 1)
                    {
                        frame[row, col] = '╣';
                    }
                    else
                    {
                        frame[row, col] = ' ';
                    }
                }
            }

            return frame;
        }
    }
}
