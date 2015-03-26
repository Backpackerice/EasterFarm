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
    using EasterFarm.Models.Presents;
    using EasterFarm.Models;

    class EasterFarmMain
    {
        static void Main()
        {
            // Setting the console height and width.
            Console.BufferHeight = Console.WindowHeight = Constants.WorldRows + 1;
            Console.BufferWidth = Console.WindowWidth = Constants.WorldCols;

            // Creating a renderer with the console height and width.
            IRenderer renderer = new ConsoleRenderer(Constants.WorldRows, Constants.WorldCols);

            // Assigning the user input to the keyboard.
            IUserInput userInput = new KeyboardInput();

            // Creating an engine of the game.
            Engine engine = new Engine(renderer, userInput);

            // Initializing the game engine.
            GameInitializator.Initialize(engine);

            // Starting the game.
            engine.Start();

            //// test Present Factory - remove eventually
            //var facotry = new PresentFactory();
            //var manager = new FarmManager();

            //var present = manager.MakePresent(PresentType.ChocoEgg, facotry);
            //manager.AddToInventory(present);
        }
    }
}
