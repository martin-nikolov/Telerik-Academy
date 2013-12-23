namespace WarMachines.Machines
{
    using System.Text;
    using WarMachines.Interfaces;

    class Fighter : Machine, IFighter
    {
        private const double InitialHealthPoints = 200;

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = InitialHealthPoints;
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());
            output.AppendFormat(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF");

            return output.ToString().TrimEnd();
        }
    }
}