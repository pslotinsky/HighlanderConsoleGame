using Faker;
using HelloWorldConsole.Events;

namespace HelloWorldConsole.Units
{
    public class Unit
    {
        private const int DEFAULT_HP = 100;
        private const int MIN_DAMAGE = 5;
        private const int MAX_DAMAGE = 10;

        public event EventHandler<UnitAttackedEventArgs>? Attacked;
        public event EventHandler<UnitKilledEventArgs>? Killed;

        public int Hp { get; set; } = DEFAULT_HP;

        public string Name { get; set; } = NameFaker.Name();

        public bool IsAlive => Hp > 0;

        public bool IsDead => !IsAlive;

        public override string ToString() => Name;

        public void Attack(Unit defender)
        {
            var random = new Random();
            var damage = random.Next(MIN_DAMAGE, MAX_DAMAGE);

            defender.Defend(this, damage);
        }

        protected void Defend(Unit attacker, int damage)
        {
            Hp = Hp > damage ? Hp - damage : 0;

            Attacked?.Invoke(this, new UnitAttackedEventArgs(attacker, damage));

            if (IsDead)
            {
                Killed?.Invoke(this, new UnitKilledEventArgs(attacker));
            }
        }
    }
}
