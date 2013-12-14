namespace WarMachines.Machines
{
    using System.Text;
    using WarMachines.Interfaces;

    class Tank : Machine, ITank
    {
        private const double InitialHealthPoints = 100;

        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            this.HealthPoints = InitialHealthPoints;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = !this.DefenseMode;

            this.DefensePoints += this.DefenseMode ? 30 : -30;
            this.AttackPoints -= this.DefenseMode ? 40 : -40;
        }

        public override string ToString()
        {
            var output = new StringBuilder(base.ToString());
            output.AppendFormat(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF");

            return output.ToString().TrimEnd();
        }
    }
}