namespace AcademyEcosystem
{
    using System;
    using System.Linq;

    public abstract class Animal : Organism
    {
        protected int sleepRemaining;

        protected Animal(string name, Point location, int size)
            : base(location, size)
        {
            this.Name = name;
            this.sleepRemaining = 0;
        }

        public AnimalState State { get; protected set; }

        public string Name { get; private set; }

        public virtual int GetMeatFromKillQuantity()
        {
            this.IsAlive = false;
            return this.Size;
        }

        public void GoTo(Point destination)
        {
            this.Location = destination;
            if (this.State == AnimalState.Sleeping)
            {
                this.Awake();
            }
        }

        public void Sleep(int time)
        {
            this.sleepRemaining = time;
            this.State = AnimalState.Sleeping;
        }

        public override void Update(int timeElapsed)
        {
            if (this.sleepRemaining == 0)
            {
                this.Awake();
            }
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Name;
        }

        protected void Awake()
        {
            this.sleepRemaining = 0;
            this.State = AnimalState.Awake;
        }
    }
}