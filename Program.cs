Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.CursorVisible = false;


var random = new Random();
int[] hps = { 100, 100, 100, 100, 100, 100 };
int index;
string scene;

for (var i = 0; i <= 100; i++)
{
    scene = "";

    for (var j = 0; j < hps.Length; j++)
    {
        scene += $"Player {j + 1}\n";
        scene += printHp(hps[j]);
        scene += "\n";
    }

    index = random.Next(0, hps.Length);
    hps[index] -= 5;

    Console.SetCursorPosition(0, 0);
    Console.Write(scene);

    Thread.Sleep(500);
}

string printHp(int hp)
{
    var result = "";

    for (var progress = 0; progress < 100; progress += 10)
    {
        if (hp - progress >= 10)
        {
            result += "█";
        }
        else if (hp - progress >= 5)
        {
            result += "▓";
        }
        else
        {
            result += "▒";
        }
    }

    result += $" {hp} \n";

    return result;
}
