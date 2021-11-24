var data = File.ReadAllLines("data.txt");

var nice = 0;
var vowels = new char[] {'a','e','i','o','u'};
var forbidden = new List<string> {"ab", "cd", "pq", "xy"};

foreach (var word in data)
{
    var vowelCount = word.Where(x => vowels.Contains(x)).Count();
    if(vowelCount<3)
        continue;

    var dd = false;
    for(int i = 0; i < word.Length-1; i++)
    {
        if(word[i] == word[i+1])
        {
            dd = true;
            break;
        }
    }
    if(!dd)
        continue;

    var bb = false;
    for(int i = 0; i < word.Length -1; i++)
    {
        if(forbidden.Contains(word.Substring(i,2)))
        {
            bb = true;
            break;
        }
    }
    if(bb)
        continue;

    nice++;
}

System.Console.WriteLine(nice);