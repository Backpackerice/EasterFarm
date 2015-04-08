namespace EasterFarm.TestWPF.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Threading;

    using EasterFarm.Common;
    using EasterFarm.GameLogic.Contracts;
    using EasterFarm.Models;
    using EasterFarm.Models.FarmObjects.Animals;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.FarmObjects.Food;
    using TestCanvas.ViewModels;


    // Implement Command Design Pattern in order to abstract behaviour into an object (property of a object). We have method in an odject 
    // It works using ICommand interface
    public class MainViewModel : INotifyPropertyChanged, IEngine
    {
        //private FarmManager farmManager;
        // private Market market;
        //private PresentFactory presentFactory;
        private static Random random;

        private ObservableCollection<GameObject> gameObjects;
        private ObservableCollection<FarmFood> farmFoods;
        private ObservableCollection<Livestock> livestocks;
        private ObservableCollection<Villain> villains;
        private ObservableCollection<Byproduct> byproducts;

        private DispatcherTimer timer;

        public MainViewModel()
        {                                                                        
            this.gameObjects = new ObservableCollection<GameObject>();
            this.farmFoods = new ObservableCollection<FarmFood>();
            this.livestocks = new ObservableCollection<Livestock>();
            this.villains = new ObservableCollection<Villain>();
            this.byproducts = new ObservableCollection<Byproduct>();

            random = new Random();

            this.DestroyObject = new RelayCommand(this.OnDestroyObjectExecute, this.OnDestroyObjectCanExecute);
            this.MinusKozunak = new RelayCommand(this.OnMinusClickedExecute, this.OnMinusClickCanExecute);
            this.PlusKozunak = new RelayCommand(this.OnPlusClickedExecute, this.OnPlusClickCanExecute);
            this.timer = new DispatcherTimer();

            this.InitialiazeGameObjectsLists();
            this.InitaliazeInventoryObjects();

            this.Start();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand DestroyObject { get; set; }

        public RelayCommand MinusKozunak { get; set; }

        public RelayCommand PlusKozunak { get; set; }

        public ObservableCollection<uint> Inventory { get; set; }

        public ObservableCollection<GameObject> GameObjects
        {
            get { return this.gameObjects; }
            private set { this.gameObjects = value; }
        }

        public void Start()
        {
            this.timer.Interval = TimeSpan.FromMilliseconds(700);
            this.timer.Tick += delegate
            {
                this.Seek(this.livestocks, typeof(FarmFood));
                this.Seek(this.villains, typeof(Livestock));
                this.Collide(this.livestocks, this.farmFoods);
                this.Collide(this.villains, this.livestocks);
                this.RebuildCollections();
                this.AddGameObject(this.ProduceNewGameObject());
            };

            this.timer.Start();
        }

        private void InitaliazeInventoryObjects()
        {
            this.Inventory = new ObservableCollection<uint> { 4, 1, 3, 4, 1, 5, 0, 0, 0, 0, 0, 0, 250 };
        }

        private void RebuildCollections()
        {
            ObservableCollection<GameObject> temp = new ObservableCollection<GameObject>();
            foreach (var item in this.gameObjects)
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

            if (this.livestocks.Count < 1)
            {
                this.GameOver();
            }

            if (this.Inventory[8] == 5)
            {
                this.HappyEaster();
            }
        }

        private void HappyEaster()
        {
            this.timer.Stop();
            MessageBox.Show("Happy Easter!!!");
        }

        private void GameOver()
        {
            this.timer.Stop();
            MessageBox.Show("Game Over!!!");
        }

        private void InitialiazeGameObjectsLists()
        {
            this.AddGameObject(new Raspberry(new MatrixCoords(1, 4)));
            this.AddGameObject(new Raspberry(new MatrixCoords(20, 21)));
            this.AddGameObject(new Blueberry(new MatrixCoords(20, 5)));
            this.AddGameObject(new Blueberry(new MatrixCoords(10, 15)));
            this.AddGameObject(new Blueberry(new MatrixCoords(10, 20)));
            this.AddGameObject(new Hen(new MatrixCoords(10, 17)));
            this.AddGameObject(new Rabbit(new MatrixCoords(10, 10)));
            this.AddGameObject(new Hen(new MatrixCoords(20, 9)));
            this.AddGameObject(new Hen(new MatrixCoords(9, 10)));
            this.AddGameObject(new Rabbit(new MatrixCoords(8, 20)));
            this.AddGameObject(new Hen(new MatrixCoords(1, 17)));
            this.AddGameObject(new Lamb(new MatrixCoords(1, 10)));
            this.AddGameObject(new Lamb(new MatrixCoords(9, 1)));
            this.AddGameObject(new Lamb(new MatrixCoords(9, 16)));
            this.AddGameObject(new Hen(new MatrixCoords(5, 8)));
        }

        private void Collide(IEnumerable<Animal> colliders, IEnumerable<GameObject> destroyables)
        {
            foreach (var destroyable in destroyables)
            {
                foreach (var collider in colliders)
                {
                    if (destroyable.TopLeft == collider.TopLeft)
                    {
                        destroyable.IsDestroyed = true;
                        Byproduct byproduct = collider.Produce(this.GetByproductColor(destroyable));
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

        private void Seek(IEnumerable<Animal> chasers, Type targetType) 
        {
            var map = this.CreateTopographicMap(targetType);
            foreach (var chaser in chasers)
            {
                chaser.Move(map);
            }
        }

        private GameObject ProduceNewGameObject()
        {
            int next = random.Next(0, Constants.Difficulty);
            if (next < Constants.Difficulty / 4) // On each n-th cicle on avarage will produce a new object.
            {
                next = random.Next(0, Constants.Difficulty);
                if (next < Constants.DifficultyLevel)
                {
                    return new Wolf(this.GetRandomMatrixCoords());
                }

                if (next < Constants.DifficultyLevel * 2)
                {
                    return new Fox(this.GetRandomMatrixCoords());
                }

                return null;
            }
            else if (next > Constants.Difficulty * 0.6)
            {
                next = random.Next(0, Constants.Difficulty);
                if (next < Constants.DifficultyLevel + Constants.Difficulty / 2)
                {
                    return new Raspberry(this.GetRandomMatrixCoords());
                }

                return new Blueberry(this.GetRandomMatrixCoords());
            }

            return null;
        }

        private MatrixCoords GetRandomMatrixCoords()
        {
            var position = new MatrixCoords(random.Next(1, Constants.WorldRowsWPF - 1), random.Next(1, (int)(Constants.WorldColsWPF)));
            while (this.gameObjects.Any(go => go.TopLeft == position))
            {
                position = new MatrixCoords(random.Next(1, Constants.WorldRowsWPF - 1), random.Next(1, (int)(Constants.WorldColsWPF)));
            }

            return position;
        }

        private void AddGameObject(GameObject gameObject)
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

        private int[,] CreateTopographicMap(Type gameObjectType)
        {
            int[,] map = new int[Constants.WorldRows, (int)(Constants.WorldCols) + 1];
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

        //public void SetInitialGameObjects()
        //{
        //    this.farmManager = new FarmManager();
        //    // this.market = Market.Instance; Market instance?? wtf?
        //    var ingredientFactory = MarketFactory.Get(Category.Ingredient);
        //    this.FillMarketCategory(ingredientFactory, IngredientType.Basket);
        //    this.presentFactory = new PresentFactory();
        //}

        //private void FillMarketCategory(ProductFactory productFactory, Enum productType)
        //{
        //    foreach (Enum type in Enum.GetValues(productType.GetType()))
        //    {
        //        IBuyable ingredient = productFactory.Get(type);
        //        this.market.AddProduct(ingredient);
        //    }
        //}

        private bool OnMinusClickCanExecute(object sender)
        {
            return this.Inventory[0] > 0;
        }

        private void OnMinusClickedExecute(object sender)
        {
            this.Inventory[0]--;
            this.Inventory[12] += 24;
        }

        private bool OnPlusClickCanExecute(object sender)
        {
            return true;
        }

        private void OnPlusClickedExecute(object sender)
        {
            if (this.Inventory[5] > 0 && this.Inventory[6] > 0 && this.Inventory[7] > 1)
            {
                this.Inventory[0]++;
                this.Inventory[5]--;
                this.Inventory[6]--;
                this.Inventory[7] -= 2;
            }
            else
            {
                MessageBox.Show("You don't have enough products to make the Kozunak!!!");
            }
            
        }

        private bool OnDestroyObjectCanExecute(object sender)
        {
            if (sender is Villain || sender is Byproduct)
            {
                return true;
            }

            return false;
        }

        private void OnDestroyObjectExecute(object sender)
        {
            this.gameObjects.Remove(sender as GameObject);
            if (sender is Milk)
            {
                this.Inventory[6]++;
            }
            else if (sender is TrophyEgg)
            {
                this.Inventory[8]++;
            }
            else if (sender is EasterEgg)
            {
                this.Inventory[7]++;
            }
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
