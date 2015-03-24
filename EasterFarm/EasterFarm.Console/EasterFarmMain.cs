namespace EasterFarm.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.GameLogic;
    using EasterFarm.GameLogic.Contracts;

    class EasterFarmMain
    {
        static void Main()
        {
            IRenderer consoleRenderer = new ConsoleRenderer();
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
