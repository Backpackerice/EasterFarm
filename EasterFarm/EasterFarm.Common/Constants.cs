using System.Runtime.Remoting.Messaging;

namespace EasterFarm.Common
{
    public static class Constants
    {
        public const int WorldRows = 20;
        public const int WorldCols = 60;
        public const double LeftRightScreenRatio = 0.5;
        public const double UpDownScreeRatio = 0.5;
        public const int Difficulty = 10; // the greater, the easyer
        public const int DifficultyLevel = 1; // should be lesser than Difficulty/2
    }
}
