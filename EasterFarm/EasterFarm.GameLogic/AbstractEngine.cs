using EasterFarm.Common;
using EasterFarm.Models;
using EasterFarm.Models.MarketPlace;
using EasterFarm.Models.Contracts;
using EasterFarm.Models.Presents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasterFarm.GameLogic
{
    public abstract class AbstractEngine
    {
        private FarmManager farmManager;
        private Market market;
        private PresentFactory presentFactory;

        protected ObservableCollection<GameObject> gameObjects;
        protected ObservableCollection<IMovable> movingObjects;

        public ObservableCollection<GameObject> GameObjects
        {
            get { return this.gameObjects; }
            private set { this.gameObjects = value; }
        }
        

        public AbstractEngine()
        {
            this.gameObjects = new ObservableCollection<GameObject>();
            this.movingObjects = new ObservableCollection<IMovable>();

        }

        public void AddGameObject(GameObject gameObject)
        {
            if (gameObject is IMovable)
            {
                this.movingObjects.Add((IMovable)gameObject);
            }

            this.gameObjects.Add(gameObject);
        }

        abstract public void Start();

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

            this.market = Market.Instance;
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
    }
}

