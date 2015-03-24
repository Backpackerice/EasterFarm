namespace EasterFarm.Common
{
    public static class Constants
    {
        static Constants()
        {
            WorldRows = 30;
            WorldCols = 50;
        }
        public static int WorldRows { get; private set; }
        public static int WorldCols { get; private set; }

    }
}
