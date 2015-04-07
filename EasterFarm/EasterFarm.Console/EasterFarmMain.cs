using System.Runtime.Remoting.Channels;

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
    using EasterFarm.Models.FarmObjects.Food;
    using EasterFarm.Models.FarmObjects.Animals;
    using EasterFarm.Models.MarketPlace;

    class EasterFarmMain
    {
        static void Main()
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
            IConsoleAim aim = ConsoleAim.Instance;

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

            //// test Present Factory - remove eventually
            //var facotry = new PresentFactory();
            //var manager = new FarmManager();

            //var present = manager.MakePresent(PresentType.ChocoEgg, facotry);
            //manager.AddToInventory(present);

            //// test custom exception
            //try
            //{
            //    throw new InsufficientAmmountException(new Present(PresentType.ChocoEgg, 20, CurrencyType.Blueberries, new Dictionary<Enum, int>()).ToString());
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //// test Product Factory
            //var product = new ProductFactory().Get(LivestockType.Hen);
            //var basket = new ProductFactory().Get(IngredientType.Basket);
            //Console.WriteLine(product.ToString());
        }
    }
}
