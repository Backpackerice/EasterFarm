using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EasterFarm.Common;
using EasterFarm.GameLogic;
using EasterFarm.Models;
using EasterFarm.Models.FarmObjects.Animals;
using EasterFarm.Models.FarmObjects.Byproducts;
using EasterFarm.Models.FarmObjects.Food;
using System.Windows.Media;

namespace EasterFarm.TestWPF.ViewModels
{
    public class MainViewModel
    {
        //public ObservableCollection<WPFRenderableObjects> Items { get; set; }

        public ObservableCollection<GameObject> Items { get; set; }
        public WPFEngine wpfEngine { get; set; }

        public MainViewModel()
        {
            // Initializing objects

            this.wpfEngine = new WPFEngine();
            this.Items = new ObservableCollection<GameObject>();

            wpfEngine.AddGameObject(new Raspberry(new MatrixCoords(1, 4)));
            wpfEngine.AddGameObject(new Raspberry(new MatrixCoords(11, 20)));
            wpfEngine.AddGameObject(new Hen(new MatrixCoords(10, 17)));
            wpfEngine.AddGameObject(new Hen(new MatrixCoords(10, 10)));
            wpfEngine.AddGameObject(new Hen(new MatrixCoords(9, 9)));
            wpfEngine.AddGameObject(new Hen(new MatrixCoords(9, 15)));
            wpfEngine.AddGameObject(new Hen(new MatrixCoords(8, 8)));

            //pseudoEngine.AddGameObject(new TestingObjects(1, 4, "RaspBerry"));
            //pseudoEngine.AddGameObject(new TestingObjects(10, 17, "RaspBerry"));
            //pseudoEngine.AddGameObject(new TestingObjects(10, 10, "Hen"));
            //pseudoEngine.AddGameObject(new TestingObjects(9, 9, "Hen"));
            //pseudoEngine.AddGameObject(new TestingObjects(9, 15, "Hen"));
            //pseudoEngine.AddGameObject(new TestingObjects(8, 8, "Hen"));

            //for (int i = 0; i < wpfEngine.GameObjects.Count; i++)
            //{
            //    Items.Add(new WPFRenderableObjects(
            //        wpfEngine.GameObjects[i].TopLeft.Col * 10,
            //        wpfEngine.GameObjects[i].TopLeft.Row * 10,
            //        wpfEngine.GameObjects[i].GetType().Name)
            //    );
            //}            

            Items = wpfEngine.GameObjects;

            wpfEngine.Start();
        }

    }
}
