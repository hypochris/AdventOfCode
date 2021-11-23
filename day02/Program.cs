var data = File.ReadAllText("data.txt");

var chars = data.ToCharArray();

var index =1;
var pos = 0;
foreach (var c in chars)
{
    if (c == '(')
        pos++;
    else
        pos--;

    if(pos == -1)
        break;
    index++;
}
System.Console.WriteLine(index);