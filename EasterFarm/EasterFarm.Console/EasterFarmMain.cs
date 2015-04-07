namespace EasterFarm.Console
{
    using System;

    using EasterFarm.Common;
    using EasterFarm.GameLogic;
    using EasterFarm.GameLogic.Contracts;

    public class EasterFarmMain
    {
        public static void Main()
        {
            Console.CursorVisible = false;

            // Setting the console height and width.
            Console.BufferHeight = Console.WindowHeight = Constants.WorldRows + 1;
            Console.BufferWidth = Console.WindowWidth = Constants.WorldCols;

            // Creating a renderer with the console height and width.
            IRenderer renderer = new ConsoleRenderer(Constants.WorldRows, Constants.WorldCols);

            // Assigning the user input to the keyboard.
            IUserKeyboardInput userInput = new KeyboardInput();

            // Creating an aim for the console user experience.
            IAim aim = Aim.Instance;

            // Ataching the aim methods to the userInput events
            userInput.OnDownPressed += (sender, args) => { aim.MoveDown(); };
            userInput.OnLeftPressed += (sender, args) => { aim.MoveLeft(); };
            userInput.OnRightPressed += (sender, args) => { aim.MoveRight(); };
            userInput.OnUpPressed += (sender, args) => { aim.MoveUp(); };

            GameInitializator gameInitializator = new GameInitializator();

            // Creating an engine of the game.
            Engine engine = new Engine(renderer, userInput, aim, gameInitializator);

            // Starting the game.
            engine.Start();
        }
    }
}
