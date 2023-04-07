using HelloWorldConsole;
using HelloWorldConsole.Units;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.CursorVisible = false;

var game = new Game
{
    Units = new UnitCollection(7),
    Timeout = 300,
};

game.Start();
