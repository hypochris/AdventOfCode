var data = File.ReadAllText("data.txt");

var coord = (0, 0);
var dict = new Dictionary<(int, int),int>();
dict.Add(coord, 1);

foreach (var step in data)
{
    if(step == '>')
        coord.Item1++;
    else if(step == '<')
        coord.Item1--;
    else if(step == '^')
        coord.Item2++;
    else if(step == 'v')
        coord.Item2--;

    if(!dict.Any(x => x.Key == coord))
        dict.Add(coord, 1);
    else
        dict[coord]++;
}

System.Console.WriteLine(dict.Count);