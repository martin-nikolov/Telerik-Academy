namespace AcademyEcosystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        protected static readonly char[] separators = new char[] { ' ' };

        protected List<Organism> allOrganisms;
        protected List<Plant> plants;
        protected List<Animal> animals;

        public Engine()
        {
            this.allOrganisms = new List<Organism>();
            this.plants = new List<Plant>();
            this.animals = new List<Animal>();
        }

        public void AddOrganism(Organism organism)
        {
            this.allOrganisms.Add(organism);

            var organismAsAnimal = organism as Animal;
            var organismAsPlant = organism as Plant;

            if (organismAsAnimal != null)
            {
                this.animals.Add(organismAsAnimal);
            }

            if (organismAsPlant != null)
            {
                this.plants.Add(organismAsPlant);
            }
        }

        public void ExecuteCommand(string command)
        {
            string[] commandWords = command.Split(Engine.separators, StringSplitOptions.RemoveEmptyEntries);

            if (commandWords[0] == "birth")
            {
                this.ExecuteBirthCommand(commandWords);
            }
            else
            {
                this.ExecuteAnimalCommand(commandWords);
            }

            this.RemoveAndReportDead();
        }

        protected virtual void ExecuteBirthCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "deer":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddOrganism(new Deer(name, position));
                        break;
                    }
                case "tree":
                    {
                        Point position = Point.Parse(commandWords[2]);
                        this.AddOrganism(new Tree(position));
                        break;
                    }
                case "bush":
                    {
                        Point position = Point.Parse(commandWords[2]);
                        this.AddOrganism(new Bush(position));
                        break;
                    }
            }
        }

        protected virtual void ExecuteAnimalCommand(string[] commandWords)
        {
            switch (commandWords[0])
            {
                case "go":
                    {
                        string name = commandWords[1];
                        Point destination = Point.Parse(commandWords[2]);
                        destination = this.HandleGo(name, destination);
                        break;
                    }
                case "sleep":
                    {
                        string name = commandWords[1];
                        int sleepTime = int.Parse(commandWords[2]);
                        this.HandleSleep(name, sleepTime);
                        break;
                    }
            }
        }

        protected virtual void RemoveAndReportDead()
        {
            foreach (var organism in this.allOrganisms)
            {
                if (!organism.IsAlive)
                {
                    Console.WriteLine("{0} is dead ;(", organism);
                }
            }

            this.allOrganisms.RemoveAll(o => !o.IsAlive);
            this.plants.RemoveAll(o => !o.IsAlive);
            this.animals.RemoveAll(o => !o.IsAlive);
        }

        protected virtual void UpdateAll(int timeElapsed)
        {
            foreach (var organism in this.allOrganisms)
            {
                organism.Update(timeElapsed);
            }
        }

        private Point HandleGo(string name, Point destination)
        {
            Animal current = this.GetAnimalByName(name);

            if (current != null)
            {
                int travelTime = Point.GetManhattanDistance(current.Location, destination);
                this.UpdateAll(travelTime);
                current.GoTo(destination);

                this.HandleEncounters(current);
            }
            return destination;
        }

        private void HandleEncounters(Animal current)
        {
            List<Organism> allEncountered = new List<Organism>();
            foreach (var organism in this.allOrganisms)
            {
                if (organism.Location == current.Location && !(organism == current))
                {
                    allEncountered.Add(organism);
                }
            }

            var currentAsHerbivore = current as IHerbivore;
            if (currentAsHerbivore != null)
            {
                foreach (var encountered in allEncountered)
                {
                    int eatenQuantity = currentAsHerbivore.EatPlant(encountered as Plant);
                    if (eatenQuantity != 0)
                    {
                        Console.WriteLine("{0} ate {1} from {2}", current, eatenQuantity, encountered);
                    }
                }
            }

            allEncountered.RemoveAll(o => !o.IsAlive);

            var currentAsCarnivore = current as ICarnivore;
            if (currentAsCarnivore != null)
            {
                foreach (var encountered in allEncountered)
                {
                    int eatenQuantity = currentAsCarnivore.TryEatAnimal(encountered as Animal);
                    if (eatenQuantity != 0)
                    {
                        Console.WriteLine("{0} ate {1} from {2}", current, eatenQuantity, encountered);
                    }
                }
            }

            this.RemoveAndReportDead();
        }

        private void HandleSleep(string name, int sleepTime)
        {
            Animal current = this.GetAnimalByName(name);
            if (current != null)
            {
                current.Sleep(sleepTime);
            }
        }

        private Animal GetAnimalByName(string name)
        {
            Animal current = null;
            foreach (var animal in this.animals)
            {
                if (animal.Name == name)
                {
                    current = animal;
                    break;
                }
            }
            return current;
        }
    }
}