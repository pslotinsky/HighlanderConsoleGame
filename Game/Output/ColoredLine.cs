namespace HelloWorldConsole.Output
{
    public class ColoredLine
    {
        public ColoredText[] Items { get; set; }

        public int? Width { get; set; }

        public int Length => Items.Sum(item => item.Length);

        public ColoredLine(params ColoredText[] items)
        {
            Items = items;
        }

        public void Print()
        {
            foreach (ColoredText item in Items)
            {
                Console.ForegroundColor = item.Color;
                Console.Write(item.Text);
            }

            var count = Width != null && Width > Length ? (int)Width - Length : 0;

            Console.WriteLine("".PadRight(count, ' '));
        }
    }
}
