using HelloWorldConsole.Units;

namespace HelloWorldConsole.Events
{
    public class UnitKilledEventArgs : EventArgs
    {
        public Unit Attacker { get; private set; }

        public UnitKilledEventArgs(Unit attacker)
        {
            Attacker = attacker;
        }
    }
}
