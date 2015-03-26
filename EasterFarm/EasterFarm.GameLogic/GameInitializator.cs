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

            GameObject raspberry = new Raspberry(new MatrixCoords(1, 4), false);
            GameObject blueBerry = new Blueberry(new MatrixCoords(15, 4),false);
            GameObject fox = new Fox(new MatrixCoords(25, 7));
            GameObject wolf = new Wolf(new MatrixCoords(27, 7));
            GameObject hen = new Hen(new MatrixCoords(25, 18));
            GameObject lamb = new Lamb(new MatrixCoords(18, 25));
            GameObject rabbit = new Rabbit(new MatrixCoords(23, 16));
            engine.AddGameObject(raspberry);
            engine.AddGameObject(blueBerry);
            engine.AddGameObject(fox);
            engine.AddGameObject(wolf);
            engine.AddGameObject(hen);
            engine.AddGameObject(lamb);
            engine.AddGameObject(rabbit);
        }
    }
}
