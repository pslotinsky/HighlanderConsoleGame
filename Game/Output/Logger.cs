using HelloWorldConsole.Events;

namespace HelloWorldConsole.Output
{
    public class Logger
    {
        private const int LOG_WIDTH = 60;
        private const int LOG_HEIGHT = 20;
        private const int HEALTHBAR_WIDTH = 20;

        private readonly List<ColoredLine> _lines = new List<ColoredLine>();

        public void OnUnitAttaked(object? sender, UnitAttackedEventArgs e)
        {
            Print(
                new ColoredText(ConsoleColor.Cyan, sender?.ToString()),
                new ColoredText(ConsoleColor.White, " recived "),
                new ColoredText(ConsoleColor.Yellow, $"{e.Damage} dmg"),
                new ColoredText(ConsoleColor.White, " from "),
                new ColoredText(ConsoleColor.Cyan, e.Attacker.ToString())
            );
        }

        public void OnUnitKilled(object? sender, UnitKilledEventArgs e)
        {
            Print(
                new ColoredText(ConsoleColor.Red, sender?.ToString()),
                new ColoredText(ConsoleColor.DarkRed, " killed by "),
                new ColoredText(ConsoleColor.Red, e.Attacker.ToString())
            );
        }

        internal void OnGameEnded(object? sender, GameEndedEventArgs e)
        {
            Print(
                new ColoredText(ConsoleColor.DarkGreen, "Game ended. The winner is "),
                new ColoredText(ConsoleColor.Green, e.Winner?.ToString())
            );
        }

        private void Print(params ColoredText[] items)
        {
            _lines.Add(new ColoredLine(items) { Width = LOG_WIDTH });

            var start = _lines.Count - 1;
            var end = Math.Max(0, start - LOG_HEIGHT);
            ColoredLine line;

            for (var i = start; i >= end; i--)
            {
                Console.SetCursorPosition(HEALTHBAR_WIDTH, start - i);

                line = _lines[i];

                line.Print();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
