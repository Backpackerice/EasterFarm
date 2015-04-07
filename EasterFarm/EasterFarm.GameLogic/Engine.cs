namespace EasterFarm.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Contracts;
    using EasterFarm.Common;
    using EasterFarm.Models;
    using EasterFarm.Models.Contracts;
    using EasterFarm.Models.FarmObjects.Animals;
    using EasterFarm.Models.FarmObjects.Byproducts;
    using EasterFarm.Models.FarmObjects.Food;
    using EasterFarm.Models.MarketPlace;
    using EasterFarm.Models.Presents;

    public class Engine
    {
        private static Random random;

        private readonly FarmManager farmManager;
        private readonly Market market;
        private readonly PresentFactory presentFactory;

        private readonly HashSet<GameObject> gameObjects;
        private readonly HashSet<FarmFood> farmFoods;
        private readonly HashSet<Livestock> livestocks;
        private readonly HashSet<Villain> villains;
        private readonly HashSet<Byproduct> byproducts;

        public Engine()
        {
        }

        public Engine(IRenderer renderer, IUserKeyboardInput userInput, IAim aim, GameInitializator gameInitializator)
        {
            this.Renderer = renderer;
            this.UserInput = userInput;
            this.Aim = aim;
            this.GameInitializator = gameInitializator;
            this.farmManager = new FarmManager();
            this.market = new Market();
            this.presentFactory = new PresentFactory();
            random = new Random();
            this.gameObjects = new HashSet<GameObject>();
            this.farmFoods = new HashSet<FarmFood>();
            this.livestocks = new HashSet<Livestock>();
            this.villains = new HashSet<Villain>();
            this.byproducts = new HashSet<Byproduct>();
        }

        internal IRenderer Renderer { get; private set; }

        internal IUserKeyboardInput UserInput { get; private set; }

        internal IAim Aim { get; private set; }

        internal GameInitializator GameInitializator { get; set; }      

        public void Start()
        {
            GameInitializator.Initialize(this.farmManager, this.market, this.presentFactory, this.gameObjects);
            this.UserInput.OnActionPressed += (sender, args) => { this.Action(); };
            this.FillGameObjectCollections(this.gameObjects);

            while (true)
            {
                this.Renderer.RenderAll();
                this.Renderer.RenderPresentFactory(this.farmManager.Inventory);
                this.Renderer.RenderMarket(this.GetMarketItems());

                Thread.Sleep(400);

                this.UserInput.ProcessInput();

                this.Renderer.ClearRenderer();

                this.Renderer.EnqueueForRendering(this.Aim);

                foreach (var gameObject in this.gameObjects)
                {
                    this.Renderer.EnqueueForRendering(gameObject);
                }

                this.Seek(this.livestocks, typeof(FarmFood));
                this.Seek(this.villains, typeof(Livestock));

                this.Collide(this.livestocks, this.farmFoods);
                this.Collide(this.villains, this.livestocks);

                this.ClearCollections();

                this.AddGameObject(this.ProduceNewGameObject());
            }
        }

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

        public void ClearCollections()
        {
            this.farmFoods.RemoveWhere(ff => ff.IsDestroyed);
            this.livestocks.RemoveWhere(ls => ls.IsDestroyed);
            this.villains.RemoveWhere(v => v.IsDestroyed);
            this.byproducts.RemoveWhere(bp => bp.IsDestroyed);
            this.gameObjects.RemoveWhere(go => go.IsDestroyed);

            //if (this.farmManager != null && this.farmManager.Inventory.Count > 0)
            //{
            //    foreach (var item in farmManager.Inventory.Keys)
            //    {
            //        if ((item as GameObject).IsDestroyed)
            //        {
            //            farmManager.RemoveFromInventory(item);
            //        }
            //    }
            //}
        }

        public void Collide(IEnumerable<Animal> colliders, IEnumerable<GameObject> destroyables)
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

        public ByproductColor GetByproductColor(GameObject gameObject)
        {
            FarmFood farmFood = gameObject as FarmFood;
            if (farmFood != null)
            {
                return farmFood.GetColor();
            }

            return ByproductColor.None;
        }

        public void Seek(IEnumerable<Animal> chasers, Type targetType)
        {
            var map = this.CreateTopographicMap(targetType);
            foreach (var chaser in chasers)
            {
                chaser.Move(map);
            }
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

        // TODO: Introduce difficulty and remove the hardcode from this method.
        public GameObject ProduceNewGameObject()
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

        public MatrixCoords GetRandomMatrixCoords()
        {
            var position = new MatrixCoords(random.Next(1, Constants.WorldRows - 1), random.Next(1, (int)(Constants.WorldCols * Constants.LeftRightScreenRatio)));

            while (this.gameObjects.Any(go => go.TopLeft == position))
            {
                position = new MatrixCoords(random.Next(1, Constants.WorldRows - 1), random.Next(1, (int)(Constants.WorldCols * Constants.LeftRightScreenRatio)));
            }

            return position;
        }

        public void FillGameObjectCollections(ICollection<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                this.AddGameObject(gameObject);
            }
        }

        public void Action()
        {
            this.DestroyObjectsInAim(this.villains);
            this.CollectByproduct(this.byproducts);
            this.DestroyObjectsInAim(this.byproducts);
        }

        public void DestroyObjectsInAim(IEnumerable<GameObject> collection)
        {
            foreach (var item in collection)
            {
                if (item.TopLeft.Row >= this.Aim.TopLeft.Row && item.TopLeft.Row < this.Aim.TopLeft.Row + this.Aim.Size
                    && item.TopLeft.Col >= this.Aim.TopLeft.Col && item.TopLeft.Col < this.Aim.TopLeft.Col + this.Aim.Size)
                {
                    item.IsDestroyed = true;
                }
            }
        }

        public void CollectByproduct(IEnumerable<Byproduct> collection)
        {
            foreach (var item in collection)
            {
                if (item.TopLeft.Row >= this.Aim.TopLeft.Row && item.TopLeft.Row < this.Aim.TopLeft.Row + this.Aim.Size
                    && item.TopLeft.Col >= this.Aim.TopLeft.Col && item.TopLeft.Col < this.Aim.TopLeft.Col + this.Aim.Size)
                {
                    this.farmManager.AddToInventory(item);
                }
            }
        }

        public IDictionary<IStorable, int> GetPresentsFromInventory()
        {
            var presents = this.farmManager.Inventory
                .Where(i => i.Key.GetType() == typeof(Present));

            return presents.ToDictionary(x => x.Key, x => x.Value);
        }

        public ICollection<IBuyable> GetMarketItems()
        {
            return this.market.BuyableProducts;
        }
    }
}
