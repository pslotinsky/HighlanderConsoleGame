using System.Text;
using HelloWorldConsole.Units;

namespace HelloWorldConsole.Output
{
    public class Scene
    {
        public void Draw(UnitCollection units)
        {
            Console.SetCursorPosition(0, 0);

            foreach (Unit unit in units)
            {
                PrintName(unit.Name);
                PrintHp(unit.Hp);

                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void PrintHp(int hp)
        {
            Console.ForegroundColor = GetHpColor(hp);
            Console.WriteLine(HpToString(hp));
        }

        private void PrintName(string name)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(name);
        }

        private ConsoleColor GetHpColor(int hp)
        {
            if (hp > 66)
            {
                return ConsoleColor.Green;
            }
            else if (hp > 33)
            {
                return ConsoleColor.Yellow;
            }
            else
            {
                return ConsoleColor.Red;
            }
        }

        private string HpToString(int hp)
        {
            var result = new StringBuilder();

            for (var progress = 0; progress < 100; progress += 10)
            {
                if (hp - progress >= 5)
                {
                    result.Append("█");
                }
                else if (hp - progress <= 0)
                {
                    result.Append("▒");
                }
                else
                {
                    result.Append("▓");
                }
            }

            result.Append($" {hp.ToString().PadLeft(3)}");

            return result.ToString();
        }
    }
}
