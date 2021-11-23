var data = File.ReadAllText("data.txt");

var coord1 = (0, 0);
var coord2 = (0, 0);
var dict = new Dictionary<(int, int),int>(); 
dict.Add(coord1, 2);

var count = 0;
foreach (var step in data.ToCharArray())
{
    if(count % 2 == 0){
            if(step == '>')
                coord1.Item1 += 1;
            else if(step == '<')
                coord1.Item1 -= 1;
            else if(step == '^')
                coord1.Item2 += 1;
            else if(step == 'v')
                coord1.Item2 -= 1;

            if(!dict.Any(x => x.Key == coord1))
                dict.Add(coord1, 1);
            else
                dict[coord1]++;
    }
        else{
            if(step == '>')
                coord2.Item1 += 1;
            else if(step == '<')
                coord2.Item1 -= 1;
            else if(step == '^')
                coord2.Item2 += 1;
            else if(step == 'v')
                coord2.Item2 -= 1;

            if(!dict.Any(x => x.Key == coord2))
                dict.Add(coord2, 1);
            else
                dict[coord2]++;
    }
    count++;
}

System.Console.WriteLine(dict.Count());