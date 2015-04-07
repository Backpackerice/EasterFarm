using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using EasterFarm.Common;
using EasterFarm.GameLogic;
using EasterFarm.Models;
using EasterFarm.Models.FarmObjects.Animals;
using EasterFarm.Models.FarmObjects.Byproducts;
using EasterFarm.Models.FarmObjects.Food;
using System.Windows.Media;
using System.Threading;
using System.Windows.Input;
using TestCanvas.ViewModels;
using System.Windows.Threading;
using EasterFarm.Models.Contracts;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using EasterFarm.Models.MarketPlace;
using EasterFarm.Models.Presents;

namespace EasterFarm.TestWPF.ViewModels
{

    // Implement Command Design Pattern in order to abstract behaviour into an object (property of a object). We have method in an odject 
    // It works using ICommand interface

    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<int> Collection { get; set; } // Checking the button. Delete later

        private FarmManager farmManager;
        private Market market;
        private PresentFactory presentFactory;
        private Random random;

        private ObservableCollection<GameObject> gameObjects;
        private ObservableCollection<FarmFood> farmFoods;
        private ObservableCollection<Livestock> livestocks;
        private ObservableCollection<Villain> villains;
        private ObservableCollection<Byproduct> byproducts;

        public event PropertyChangedEventHandler PropertyChanged;
        DispatcherTimer timer;
        private ICommand clickedMinus;
        private ICommand clickedPlus;

        public MainViewModel()
        {
            this.Collection = new ObservableCollection<int> { 5, 5, 5, 5 }; /// Button checker
                                                                            
            this.gameObjects = new ObservableCollection<GameObject>();
            this.farmFoods = new ObservableCollection<FarmFood>();
            this.livestocks = new ObservableCollection<Livestock>();
            this.villains = new ObservableCollection<Villain>();
            this.byproducts = new ObservableCollection<Byproduct>();

            this.random = new Random();

            this.DestroyObject = new RelayCommand(OnDestroyObjectExecute, OnDestroyObjectCanExecute);
            this.timer = new DispatcherTimer();

            InitialiazeGameObjectsLists();

            Start();
        }

        public RelayCommand DestroyObject { get; set; }

        public ICommand MinusCom
        {
            get
            {
                if (this.clickedMinus == null)
                {
                    this.clickedMinus = new RelayCommand(this.Minus);
                }
                return clickedMinus;
            }
        }

        public ICommand PlusCom
        {
            get
            {
                if (this.clickedPlus == null)
                {
                    this.clickedPlus = new RelayCommand(this.Plus);
                }
                return clickedPlus;
            }
        }

        public ObservableCollection<GameObject> GameObjects
        {
            get { return this.gameObjects; }
            private set { this.gameObjects = value; }
        }

        private void RebuildCollections() // Check how Simo did this, so you can implement the logic for the different types of GameObject
        {
            ObservableCollection<GameObject> temp = new ObservableCollection<GameObject>();
            foreach (var item in gameObjects)
            {
                temp.Add(item);
            }
            this.gameObjects.Clear();
            this.farmFoods.Clear();
            this.livestocks.Clear();
            this.villains.Clear();
            this.byproducts.Clear();
            foreach (var item in temp)
            {
                if (!item.IsDestroyed)
                {
                    this.gameObjects.Add(item);
                    if (item is FarmFood)
                    {
                        this.farmFoods.Add(item as FarmFood);
                    }
                    if (item is Livestock)
                    {
                        this.livestocks.Add(item as Livestock);
                    }
                    if (item is Villain)
                    {
                        this.villains.Add(item as Villain);
                    }
                    if (item is Byproduct)
                    {
                        this.byproducts.Add(item as Byproduct);
                    }
                }
            }
        }

        private void InitialiazeGameObjectsLists()
        {
            this.AddGameObject(new Raspberry(new MatrixCoords(1, 4)));
            this.AddGameObject(new Raspberry(new MatrixCoords(11, 20)));
            this.AddGameObject(new Hen(new MatrixCoords(10, 17)));
            this.AddGameObject(new Hen(new MatrixCoords(10, 10)));
            this.AddGameObject(new Hen(new MatrixCoords(9, 9)));
            this.AddGameObject(new Hen(new MatrixCoords(9, 15)));
            this.AddGameObject(new Hen(new MatrixCoords(8, 8)));
            this.AddGameObject(new Hen(new MatrixCoords(1, 17)));
            this.AddGameObject(new Hen(new MatrixCoords(1, 10)));
            this.AddGameObject(new Hen(new MatrixCoords(9, 1)));
            this.AddGameObject(new Hen(new MatrixCoords(9, 16)));
            this.AddGameObject(new Hen(new MatrixCoords(5, 8)));
        }

        public void Start()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += delegate
            {
                this.Seek(livestocks, typeof(FarmFood));
                this.Seek(villains, typeof(Livestock));

                this.Collide(livestocks, farmFoods);
                this.Collide(villains, livestocks);

                //    ClearCollections();
                this.RebuildCollections();

                this.AddGameObject(this.ProduceNewGameObject());
            };
            timer.Start();
        }

        //private void ClearCollections()
        //{
        //    farmFoods.RemoveWhere(ff => ff.IsDestroyed);
        //    livestocks.RemoveWhere(ls => ls.IsDestroyed);
        //    villains.RemoveWhere(v => v.IsDestroyed);
        //    byproducts.RemoveWhere(bp => bp.IsDestroyed);
        //    gameObjects.RemoveWhere(go => go.IsDestroyed);
        //}

        private void Collide(IEnumerable<Animal> colliders, IEnumerable<GameObject> destroyables)
        {
            foreach (var destroyable in destroyables)
            {
                foreach (var collider in colliders)
                {
                    if (destroyable.TopLeft == collider.TopLeft)
                    {
                        destroyable.IsDestroyed = true;
                        Byproduct byproduct = collider.Produce((GetByproductColor(destroyable)));
                        if (byproduct != null)
                        {
                            this.AddGameObject(byproduct);
                        }
                    }
                }
            }
        }

        private ByproductColor GetByproductColor(GameObject gameObject)
        {
            FarmFood farmFood = gameObject as FarmFood;
            if (farmFood != null)
            {
                return farmFood.GetColor();
            }
            return ByproductColor.None;
        }

        private void Seek(IEnumerable<Animal> chasers, Type targetType) // The move method is used in here
        {
            var map = this.CreateTopographicMap(targetType);
            foreach (var chaser in chasers)
            {
                chaser.Move(map); // the move method should be considered!!!!!!!!
            }
        }

        private GameObject ProduceNewGameObject()
        {
            int next = this.random.Next(0, Constants.Difficulty);
            if (next < Constants.Difficulty / 4) // On each n-th cicle on avarage will produce a new object.
            {
                next = random.Next(0, Constants.Difficulty);
                if (next < Constants.DifficultyLevel)
                {
                    return new Wolf(GetRandomMatrixCoords());
                }
                if (next < Constants.DifficultyLevel * 2)
                {
                    return new Fox(GetRandomMatrixCoords());
                }
                return null;
            }
            else if (next > Constants.Difficulty * 0.6)
            {
                next = random.Next(0, Constants.Difficulty);
                if (next < Constants.DifficultyLevel + Constants.Difficulty / 2)
                {
                    return new Raspberry(GetRandomMatrixCoords());
                }
                return new Blueberry(GetRandomMatrixCoords());
            }
            return null;
        }

        private MatrixCoords GetRandomMatrixCoords()
        {
            var position = new MatrixCoords(random.Next(1, Constants.WorldRows - 1), random.Next(1, (int)(Constants.WorldCols * Constants.LeftRightScreenRatio)));
            while (gameObjects.Any(go => go.TopLeft == position))
            {
                position = new MatrixCoords(random.Next(1, Constants.WorldRows - 1), random.Next(1, (int)(Constants.WorldCols * Constants.LeftRightScreenRatio)));
            }
            return position;
        }

        //private void FillGameObjectCollections(ICollection<GameObject> gameObjects) // this is not needed at the moment
        //{
        //    foreach (var gameObject in gameObjects)
        //    {
        //        this.AddGameObject(gameObject);
        //    }
        //}

        public void AddGameObject(GameObject gameObject)
        {
            if (gameObject == null)
            {
                return;
            }

            var farmFood = gameObject as FarmFood;
            if (farmFood != null)
            {
                this.farmFoods.Add(farmFood);
            }

            var livestock = gameObject as Livestock;
            if (livestock != null)
            {
                this.livestocks.Add(livestock);
            }

            var villain = gameObject as Villain;
            if (villain != null)
            {
                this.villains.Add(villain);
            }

            var byproduct = gameObject as Byproduct;
            if (byproduct != null)
            {
                this.byproducts.Add(byproduct);
            }

            this.gameObjects.Add(gameObject);
        }

        public int[,] CreateTopographicMap(Type gameObjectType)
        {
            int[,] map = new int[Constants.WorldRows, (int)(Constants.WorldCols * Constants.LeftRightScreenRatio) + 1];
            int mapHeight = map.GetLength(0);
            int mapWidth = map.GetLength(1);

            for (int row = 1; row < mapHeight - 1; row++)
            {
                for (int col = 1; col < mapWidth - 1; col++)
                {
                    map[row, col] = -1;
                }
            }

            for (int row = 0; row < mapHeight; row++)
            {
                map[row, 0] = int.MaxValue;
                map[row, mapWidth - 1] = int.MaxValue;
            }

            for (int col = 1; col < mapWidth - 1; col++)
            {
                map[0, col] = int.MaxValue;
                map[mapHeight - 1, col] = int.MaxValue;
            }

            Queue<MatrixCoords> queue = new Queue<MatrixCoords>();

            foreach (var gameObject in this.gameObjects)
            {
                if (gameObject.GetType().IsSubclassOf(gameObjectType) || gameObject.GetType() == gameObjectType)
                {
                    map[gameObject.TopLeft.Row, gameObject.TopLeft.Col] = 0;
                    queue.Enqueue(gameObject.TopLeft);
                }
            }

            while (queue.Count > 0)
            {
                MatrixCoords currentCoords = queue.Dequeue();
                int row = currentCoords.Row;
                int col = currentCoords.Col;
                for (int i = (row - 1 > 0 ? row - 1 : 0); i <= (row + 1 <= mapHeight - 1 ? row + 1 : mapHeight - 1); i++)
                {
                    for (int j = (col - 1 > 0 ? col - 1 : 0); j <= (col + 1 <= mapWidth - 1 ? col + 1 : mapWidth - 1); j++)
                    {
                        if (map[i, j] == -1)
                        {
                            map[i, j] = map[row, col] + 1;
                            queue.Enqueue(new MatrixCoords(i, j));
                        }
                    }
                }
            }
            return map;
        }

        public void SetInitialGameObjects()
        {
            this.farmManager = new FarmManager();

            // this.market = Market.Instance; Market instance?? wtf?
            var ingredientFactory = EasterFarm.Models.MarketPlace.MarketFactory.Get(Category.Ingredient);
            this.FillMarketCategory(ingredientFactory, IngredientType.Basket);

            this.presentFactory = new PresentFactory();
        }

        private void FillMarketCategory(ProductFactory productFactory, Enum productType)
        {
            foreach (Enum type in Enum.GetValues(productType.GetType()))
            {
                IBuyable ingredient = productFactory.Get(type);
                this.market.AddProduct(ingredient);
            }
        }

        private bool CanClick()
        {
            return true;
        }

        private void Minus(object obj)
        {
            this.Collection[0]--;
        }

        private void Plus(object obj)
        {
            this.Collection[0]++;
        }

        private bool OnDestroyObjectCanExecute(object sender)
        {
            if (sender is Hen)
            {
                return true;
            }
            return false;
        }

        private void OnDestroyObjectExecute(object sender)
        {
            gameObjects.Remove(sender as GameObject);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
