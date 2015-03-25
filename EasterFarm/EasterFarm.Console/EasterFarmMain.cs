namespace EasterFarm.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Common;
    using EasterFarm.GameLogic;
    using EasterFarm.GameLogic.Contracts;

    class EasterFarmMain
    {
        static void Main()
        {
            Console.WindowHeight = Console.BufferHeight = Constants.WorldRows;
            Console.WindowWidth = Console.BufferWidth = Constants.WorldCols;

            IRenderer consoleRenderer = new ConsoleRenderer(Constants.WorldRows, Constants.WorldCols);
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
