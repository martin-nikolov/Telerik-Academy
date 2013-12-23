namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    abstract class Machine : IMachine
    {
        private string name = null;
        private IPilot pilot = null;

        public Machine()
        {
            this.Targets = new List<string>();
        }

        public Machine(string name, double attackPoints, double defensePoints)
            : this()
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Name");

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Pilot");

                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; set; }

        public double DefensePoints { get; set; }

        public IList<string> Targets { get; private set; }

        public void Attack(string target)
        {
            if (this.Pilot != null)
            {
                this.DefensePoints = 100;
                this.Targets.Add(target);
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("- {0}\n", this.Name);
            output.AppendFormat(" *Type: {0}\n", this.GetType().Name);
            output.AppendFormat(" *Health: {0}\n", this.HealthPoints);
            output.AppendFormat(" *Attack: {0}\n", this.AttackPoints);
            output.AppendFormat(" *Defense: {0}\n", this.DefensePoints);
            output.AppendFormat(" *Targets: {0}\n", this.Targets.Count > 0 ? string.Join(", ", this.Targets) : "None");

            return output.ToString();
        }
    }
}