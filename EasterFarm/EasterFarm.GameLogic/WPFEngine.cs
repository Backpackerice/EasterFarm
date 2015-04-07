using EasterFarm.Models;
using EasterFarm.Models.Contracts;
using EasterFarm.Models.MarketPlace;
using EasterFarm.Models.Presents;
using EasterFarm.Models.FarmObjects.Food;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EasterFarm.Models.FarmObjects.Animals;

namespace EasterFarm.GameLogic
{
    public class WPFEngine : AbstractEngine
    {
        public override void Start()
        {
            // this.SetInitialGameObjects();
                int[,] map = CreateTopographicMap(typeof(FarmFood));

                foreach (IMovable movingObject in movingObjects)
                {
                    movingObject.Move(map);
                }
            //{
            //    Thread.Sleep(2000);

            //    Random rand = new Random();

            //    this.AddGameObject(new Hen(new MatrixCoords(rand.Next(0, 15), rand.Next(0, 15))));

            //}
        }

    }
}
