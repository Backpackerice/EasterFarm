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

        public char[,] Image { get; private set; }

        public static ConsoleFrame Instance
        {
            get { return instance ?? (instance = new ConsoleFrame()); }
        }

        private static char[,] GetScreenFrameImage()
        {
            char[,] frame = new char[Constants.WorldRows, Constants.WorldCols];

            for (int row = 1; row < frame.GetLength(0) - 1; row++)
            {
                for (int col = 1; col < frame.GetLength(1) - 1; col++)
                {
                    frame[row, col] = ' ';
                }
            }

            for (int col = 1; col < (int)(Constants.LeftRightScreenRatio * frame.GetLength(1)); col++)
            {
                frame[0, col] = '═';
                frame[frame.GetLength(0) - 1, col] = '═';
            }

            for (int col = (int)(Constants.LeftRightScreenRatio * frame.GetLength(1)) + 1; col < frame.GetLength(1) - 1; col++)
            {
                frame[0, col] = '═';
                frame[(int)(Constants.UpDownScreeRatio * frame.GetLength(0)), col] = '═';
                frame[frame.GetLength(0) - 1, col] = '═';
            }

            for (int row = 1; row < frame.GetLength(0) - 1; row++)
            {
                frame[row, 0] = '║';
                frame[row, (int)(Constants.LeftRightScreenRatio * frame.GetLength(1))] = '║';
                frame[row, frame.GetLength(1) - 1] = '║';
            }

            frame[0, 0] = '╔';
            frame[0, (int)(Constants.LeftRightScreenRatio * frame.GetLength(1))] = '╦';
            frame[0, frame.GetLength(1) - 1] = '╗';

            frame[(int)(Constants.UpDownScreeRatio * frame.GetLength(0)), (int)(Constants.LeftRightScreenRatio * frame.GetLength(1))] = '╠';
            frame[(int)(Constants.UpDownScreeRatio * frame.GetLength(0)), frame.GetLength(1) - 1] = '╣';

            frame[frame.GetLength(0) - 1, 0] = '╚';
            frame[frame.GetLength(0) - 1, (int)(Constants.LeftRightScreenRatio * frame.GetLength(1))] = '╩';
            frame[frame.GetLength(0) - 1, frame.GetLength(1) - 1] = '╝';

            return frame;
        }
    }
}
