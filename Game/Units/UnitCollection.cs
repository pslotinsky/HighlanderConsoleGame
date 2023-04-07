using Faker;
using System.Collections;

namespace HelloWorldConsole.Units
{
    public class UnitCollection : IEnumerable
    {
        private const int DEFAULT_COUNT = 5;

        public Unit[] FindAlive() => _units.Where(unit => unit.IsAlive).ToArray();

        private readonly Unit[] _units;

        public UnitCollection(int count = DEFAULT_COUNT)
        {
            _units = CreateUnits(count);
        }

        public Unit PickRandom()
        {
            return ArrayFaker.SelectFrom(FindAlive());
        }

        public Unit PickRandomExcept(Unit[] exceptions)
        {
            var units = FindAlive().Except(exceptions).ToArray();

            return ArrayFaker.SelectFrom(units);
        }

        private Unit[] CreateUnits(int count)
        {
            return new Unit[count].Select(_ => new Unit()).ToArray();
        }

        public IEnumerator GetEnumerator()
        {
            return _units.GetEnumerator();
        }
    }
}
