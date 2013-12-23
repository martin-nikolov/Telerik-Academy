namespace WarMachines.Interfaces
{
    public interface ITank : IMachine
    {
        bool DefenseMode { get; }

        void ToggleDefenseMode();
    }
}