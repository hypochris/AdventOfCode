using System.Text.RegularExpressions;
using System.Text;

var data = File.ReadAllLines("data1.txt");

var escaped = 0;
var unescaped = 0;
foreach (var line in data)
{
    unescaped += line.Length;
    escaped += ToLiteral(line).Length;

    System.Console.WriteLine($"{ToLiteral(line)} - {ToLiteral(line).Length}");
}

System.Console.WriteLine($"{escaped} - {unescaped}");
System.Console.WriteLine(escaped - unescaped);