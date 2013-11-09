using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyPopcorn
{
    public class Engine
    {
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<GameObject> staticObjects;
        Racket playerRacket;
        int sleepTime;

        public Engine(IRenderer renderer, IUserInterface userInterface, int sleepTime = 500)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
            this.SleepTime = sleepTime;
        }

        /// <summary>
        /// Task 2
        /// </summary>
        public int SleepTime
        {
            get { return this.sleepTime; }
            private set
            {
                if (this.sleepTime < 0)
                    throw new ArgumentException();
                
                this.sleepTime = value;
            }
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                if (obj is Racket)
                {
                    this.AddRacket(obj);
                }
                else
                {
                    this.AddStaticObject(obj);
                }
            }
        }

        public virtual void MovePlayerRacketLeft()
        {
            this.playerRacket.MoveLeft();
        }

        public virtual void MovePlayerRacketRight()
        {
            this.playerRacket.MoveRight();
        }

        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(this.SleepTime);

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }
            }
        }

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        /// <summary>
        /// Task 3
        /// </summary>
        private void AddRacket(GameObject obj)
        {
            this.staticObjects.RemoveAll(item => item is Racket);
            this.allObjects.RemoveAll(item => item is Racket);

            this.playerRacket = obj as Racket;
            this.AddStaticObject(obj);
        }
    }
}