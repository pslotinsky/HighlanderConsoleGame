using HelloWorldConsole.Events;
using HelloWorldConsole.Output;
using HelloWorldConsole.Units;

namespace HelloWorldConsole
{
    public class Game
    {
        private const int DEFAULT_TIMEOUT = 500;

        public event EventHandler<GameEndedEventArgs>? GameEnded;

        public UnitCollection Units { get; set; } = new UnitCollection();

        public int Timeout { get; set; } = DEFAULT_TIMEOUT;

        private bool IsEnded => Units.FindAlive().Length <= 1;

        private readonly Logger _logger = new Logger();

        private readonly Scene _scene = new Scene();

        public void Start()
        {
            Sunscribe();
            Draw();

            while (!IsEnded)
            {
                MakeTurn();

                Wait();
            }

            var winner = GetWinner();

            GameEnded?.Invoke(this, new GameEndedEventArgs { Winner = winner });

            Console.ReadLine();
        }

        private void MakeTurn()
        {
            var attaker = Units.PickRandom();
            var defender = Units.PickRandomExcept(new[] { attaker });

            attaker.Attack(defender);
        }

        private Unit GetWinner()
        {
            if (!IsEnded)
            {
                throw new InvalidOperationException("Can't determinate winner while game still in progress");
            }

            var alive = Units.FindAlive();

            if (alive.Length > 1)
            {
                throw new InvalidOperationException("Only one unit can survive");
            }

            if (alive.Length == 0)
            {
                throw new InvalidOperationException("There are no winners");
            }

            return alive[0];
        }

        private void Wait()
        {
            Thread.Sleep(Timeout);
        }

        private void Draw()
        {
            _scene.Draw(Units);
        }

        private void Sunscribe()
        {
            foreach (Unit unit in Units)
            {
                unit.Attacked += _logger.OnUnitAttaked;
                unit.Attacked += (object? sender, UnitAttackedEventArgs e) => Draw();
                unit.Killed += _logger.OnUnitKilled;
            }

            GameEnded += _logger.OnGameEnded;
        }

    }
}
