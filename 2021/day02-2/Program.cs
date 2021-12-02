var data = File.ReadAllLines("data.txt");

var depth = 0;
var horiz = 0;
var aim = 0;

foreach (var line in data)
{
    var direction = line.Split(" ")[0];
    var num = int.Parse(line.Split(" ")[1]);

    switch (direction)
    {
        case "forward":
        horiz+=num;
        depth+=aim*num;
        break;
        case "up":
        aim-=num;
        break;
        case "down":
        aim+=num;
        break;
    }   
}
System.Console.WriteLine(depth*horiz);