namespace HelloWorldConsole.Output
{
    public class ColoredText
    {
        public string Text { get; set; }

        public ConsoleColor Color { get; set; }

        public int Length => Text.Length;

        public ColoredText(ConsoleColor color, string? text)
        {
            Color = color;
            Text = text ?? "";
        }

        public void Print()
        {
            Console.ForegroundColor = Color;
            Console.Write(Text);
        }
    }
}
