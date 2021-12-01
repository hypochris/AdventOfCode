var data = File.ReadAllLines("data.txt");
var dataInt = data.Select(x => int.Parse(x.Trim())).ToArray();

var count = 0;
for (int i = 0; i < dataInt.Length-3; i++)
{
    var a = dataInt[i] + dataInt[i+1] + dataInt[i+2];
    var b = dataInt[i+1] + dataInt[i+2] + dataInt[i+3];

    if(a < b)
        count++;
}

System.Console.WriteLine(count);