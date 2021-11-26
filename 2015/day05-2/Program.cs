var data = File.ReadAllLines("data.txt");

var nice = 0;
foreach (var word in data)
{
    var knownPairs = new List<string>();

    var aa = false;
    for(int i = 0; i < word.Length-1; i++)
    {
        var pair = word.Substring(i,2);

        if(word[(i + 2)..].Contains(pair))
        {
            aa = true;
            continue;
        }
    }

    if(!aa)
    {
        System.Console.WriteLine($"{word} - fail 1");
        continue;
    }

    var bb = false;
    for(var i = 0; i < word.Length - 2; i++)
    {
        if(word.Substring(i,1) == word.Substring(i+2,1))
        {
            bb = true;
            break;
        }
    }
    if(!bb)
    {
        System.Console.WriteLine($"{word} - fail 2");
        continue;
    }

    System.Console.WriteLine($"{word} - success");
    nice++;
}

System.Console.WriteLine(nice);