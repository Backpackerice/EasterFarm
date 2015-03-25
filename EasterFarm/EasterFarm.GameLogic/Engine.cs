namespace EasterFarm.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using Contracts;
    using EasterFarm.Models;
    using EasterFarm.Models.Contracts;

    public class Engine
    {
        private IRenderer renderer;
        private IUserInput userInput;

        private ICollection<GameObject> gameObjects;

        public Engine(IRenderer renderer, IUserInput userInput)
        {
            this.renderer = renderer;
            this.userInput = userInput;
            this.gameObjects = new List<GameObject>();
        }

        public void AddGameObject(GameObject gameObject)
        {
            this.gameObjects.Add(gameObject);
        }

        public void Start()
        {
            while (true)
            {
                this.renderer.RenderAll();

                Thread.Sleep(200);

                this.userInput.ProcessInput();

                this.renderer.ClearRenderer();

                foreach (var gameObject in gameObjects)
                {
                    this.renderer.EnqueueForRendering(gameObject);
                }
            }
        }
    }
}
