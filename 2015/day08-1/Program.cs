using System.Text.RegularExpressions;

var data = File.ReadAllLines("data.txt");

var escaped = 0;
var unescaped = 0;
foreach (var line in data)
{
    escaped += line.Length;
    unescaped += Regex.Unescape(line[1..^1]).Length;
}

System.Console.WriteLine(escaped - unescaped);