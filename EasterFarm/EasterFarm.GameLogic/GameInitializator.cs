namespace EasterFarm.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EasterFarm.Models.FarmObjects.Animals;
    using EasterFarm.Models;
    using EasterFarm.Models.FarmObjects.Food;

    public static class GameInitializator
    {
        public static void Initialize(Engine engine)
        {
            ScreenFrame screenFrame = ScreenFrame.Instance;
            engine.AddGameObject(screenFrame);

            GameObject gameObject = new Raspberry(new MatrixCoords(1, 4), false);
            engine.AddGameObject(gameObject);

            gameObject = new Blueberry(new MatrixCoords(20, 20), false);
            engine.AddGameObject(gameObject);

            gameObject = new Hen(new MatrixCoords(10, 10));
            engine.AddGameObject(gameObject);
        }
    }
}
