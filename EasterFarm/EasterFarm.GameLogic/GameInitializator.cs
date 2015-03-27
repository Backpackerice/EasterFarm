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
            ScreenFrame screenFrame = ScreenFrame.Instance;
            engine.AddGameObject(screenFrame);
			
            GameObject farmFood = new Raspberry(new MatrixCoords(1, 4), false);
            engine.AddGameObject(farmFood);
			
            farmFood = new Blueberry(new MatrixCoords(20, 20), false);
            engine.AddGameObject(farmFood);
        }
    }
}
