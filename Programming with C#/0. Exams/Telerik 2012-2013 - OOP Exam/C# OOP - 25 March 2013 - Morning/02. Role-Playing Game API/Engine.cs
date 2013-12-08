namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public static readonly char[] separators = new char[] { ' ' };

        protected List<WorldObject> allObjects;
        protected List<IControllable> controllables;
        protected List<IResource> resources;

        public Engine()
        {
            this.allObjects = new List<WorldObject>();
            this.controllables = new List<IControllable>();
            this.resources = new List<IResource>();
        }

        public void AddObject(WorldObject obj)
        {
            this.allObjects.Add(obj);

            IControllable objAsControllable = obj as IControllable;
            if (objAsControllable != null)
            {
                this.controllables.Add(objAsControllable);
            }

            IResource objAsResource = obj as IResource;
            if (objAsResource != null)
            {
                this.resources.Add(objAsResource);
            }
        }

        public void ExecuteCommand(string command)
        {
            string[] commandWords = command.Split(Engine.separators, StringSplitOptions.RemoveEmptyEntries);

            if (commandWords[0] == "create")
            {
                this.ExecuteCreateObjectCommand(commandWords);
            }
            else
            {
                this.ExecuteControllableCommand(commandWords);
            }

            this.RemoveDestroyed();
        }

        public virtual void ExecuteCreateObjectCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "lumberjack":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Lumberjack(name, position, owner));
                        break;
                    }
                case "guard":
                    {
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Guard(name, position, owner));
                        break;
                    }
                case "tree":
                    {
                        int size = int.Parse(commandWords[2]);
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Tree(size, position));
                        break;
                    }
            }
        }

        public virtual void ExecuteControllableCommand(string[] commandWords)
        {
            string controllableName = commandWords[0];
            IControllable current = null;

            for (int i = 0; i < this.controllables.Count; i++)
            {
                if (controllableName == this.controllables[i].Name)
                {
                    current = this.controllables[i];
                }
            }

            if (current != null)
            {
                switch (commandWords[1])
                {
                    case "go":
                        {
                            this.HandleGoCommand(commandWords, current);
                            break;
                        }
                    case "attack":
                        {
                            this.HandleAttackCommand(current);
                            break;
                        }
                    case "gather":
                        {
                            this.HandleGatherCommand(current);
                            break;
                        }
                }
            }
        }

        private void RemoveDestroyed()
        {
            this.allObjects.RemoveAll(obj => obj.IsDestroyed);
            this.controllables.RemoveAll(obj => obj.IsDestroyed);
            this.resources.RemoveAll(obj => obj.IsDestroyed);
        }

        private void HandleGatherCommand(IControllable current)
        {
            var currentAsGatherer = current as IGatherer;
            if (currentAsGatherer != null)
            {
                IResource resource = null;
                foreach (var obj in this.resources)
                {
                    if (obj.Position == current.Position)
                    {
                        resource = obj;
                        break;
                    }
                }

                if (resource != null)
                {
                    this.HandleGathering(currentAsGatherer, resource);
                }
                else
                {
                    Console.WriteLine("No resource to gather at {0}'s position", current);
                }
            }
            else
            {
                Console.WriteLine("{0} can't do that", current);
            }
        }

        private void HandleAttackCommand(IControllable current)
        {
            var currentAsFighter = current as IFighter;
            if (currentAsFighter != null)
            {
                List<WorldObject> availableTargets = new List<WorldObject>();
                foreach (var obj in this.allObjects)
                {
                    if (obj.Position == current.Position)
                    {
                        availableTargets.Add(obj);
                    }
                }

                int targetIndex = currentAsFighter.GetTargetIndex(availableTargets);
                if (targetIndex != -1)
                {
                    this.HandleBattle(currentAsFighter, availableTargets[targetIndex]);
                }
                else
                {
                    Console.WriteLine("No targets to attack at {0}'s position", current);
                }
            }
            else
            {
                Console.WriteLine("{0} can't do that", current);
            }
        }

        private void HandleGathering(IGatherer gatherer, IResource resource)
        {
            bool gatheringSuccess = gatherer.TryGather(resource);
            if (gatheringSuccess)
            {
                Console.WriteLine("{0} gathered {1} {2} from {3}", gatherer, resource.Quantity, resource.Type, resource);
                resource.HitPoints = 0;
            }
        }

        private void HandleBattle(IFighter attacker, WorldObject defender)
        {
            var defenderAsFighter = defender as IFighter;
            int defenderDefensePoints = 0;

            if (defenderAsFighter != null)
            {
                defenderDefensePoints = defenderAsFighter.DefensePoints;
            }

            int damage = attacker.AttackPoints - defenderDefensePoints;

            if (damage < 0)
            {
                damage = 0;
            }

            if (damage > defender.HitPoints)
            {
                damage = defender.HitPoints;
            }

            defender.HitPoints -= damage;

            Console.WriteLine("{0} attacked {1} and did {2} damage", attacker, defender, damage);
        }

        private void HandleGoCommand(string[] commandWords, IControllable current)
        {
            var currentAsMoving = current as MovingObject;
            currentAsMoving.GoTo(Point.Parse(commandWords[2]));
            Console.WriteLine("{0} is now at position {1}", current, current.Position);
        }
    }
}