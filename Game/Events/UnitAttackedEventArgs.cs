using HelloWorldConsole.Units;

namespace HelloWorldConsole.Events
{
    public class UnitAttackedEventArgs : EventArgs
    {
        public Unit Attacker { get; private set; }
        public int Damage { get; private set; }

        public UnitAttackedEventArgs(Unit attacker, int damage)
        {
            Attacker = attacker;
            Damage = damage;
        }
    }
}
