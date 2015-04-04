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
    using EasterFarm.Models.MarketPlace;

    public static class GameInitializator
    {
        public static void Initialize(Engine engine)
        {
            GameObject gameObject = new Raspberry(new MatrixCoords(1, 4));
            engine.AddGameObject(gameObject);

            gameObject = new Blueberry(new MatrixCoords(20, 20));
            engine.AddGameObject(gameObject);

            gameObject = new Hen(new MatrixCoords(10, 10));
            engine.AddGameObject(gameObject);

            //TODO : .Clone() instead? - Prototype design pattern
            gameObject = new Hen(new MatrixCoords(9, 9));
            engine.AddGameObject(gameObject);

            gameObject = new Hen(new MatrixCoords(15, 15));
            engine.AddGameObject(gameObject);

            gameObject = new Hen(new MatrixCoords(8, 8));
            engine.AddGameObject(gameObject);
        }
    }
}
