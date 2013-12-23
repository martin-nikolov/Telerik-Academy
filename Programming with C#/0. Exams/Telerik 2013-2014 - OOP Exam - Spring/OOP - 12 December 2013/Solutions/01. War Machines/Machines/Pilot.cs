namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WarMachines.Interfaces;

    class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> engagedMachines;

        public Pilot(string name)
        {
            this.Name = name;
            this.engagedMachines = new List<IMachine>();
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

        public void AddMachine(IMachine machine)
        {
            this.engagedMachines.Add(machine);

            // Ordering machines
            this.engagedMachines =
                new List<IMachine>(this.engagedMachines.OrderBy(i => i.HealthPoints).ThenBy(i => i.Name).ToList());
        }

        public string Report()
        {
            var output = new StringBuilder();

            string numberOfMachineText = string.Empty;

            if (this.engagedMachines.Count > 0)
            {
                numberOfMachineText = this.engagedMachines.Count + " machine";

                if (this.engagedMachines.Count > 1)
                {
                    numberOfMachineText += "s";
                }

                numberOfMachineText += "\n";
            }
            else
            {
                numberOfMachineText = "no machines";
            }

            output.AppendFormat("{0} - {1}", this.Name, numberOfMachineText);

            foreach (var machine in this.engagedMachines)
            {
                if (machine.Pilot != null)
                {
                    output.AppendLine(machine.ToString());
                }
            }

            return output.ToString().TrimEnd();
        }
    }
}