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
            GameObject Raspberry = new Raspberry(new MatrixCoords(3, 4), new char[,] {{'R'}}, false);

            engine.AddGameObject(Raspberry);
        }
    }
}
