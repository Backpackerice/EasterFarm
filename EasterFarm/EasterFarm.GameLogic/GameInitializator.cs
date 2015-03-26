namespace EasterFarm.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using EasterFarm.Models;
    using EasterFarm.Models.FarmObjects.Food;

    public static class GameInitializator
    {
        public static void Initialize(Engine engine)
        {
            ScreenFrame screenFrame = ScreenFrame.Instance;
            engine.AddGameObject(screenFrame);

            GameObject Raspberry = new Raspberry(new MatrixCoords(1, 4), new char[,] {{'R'}}, false);
            engine.AddGameObject(Raspberry);
        }
    }
}
