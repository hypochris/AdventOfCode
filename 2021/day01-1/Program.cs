var data = File.ReadAllLines("data.txt");
var dataInt = data.Select(x => int.Parse(x.Trim())).ToArray();

var count = 0;
for (int i = 0; i < dataInt.Length-1; i++)
{
    if(dataInt[i] < dataInt[i+1])
        count++;
}

System.Console.WriteLine(count);