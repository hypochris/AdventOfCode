var data = File.ReadAllText("data.txt");

var chars = data.ToCharArray();

var index =1;
var pos = 0;
foreach (var c in chars)
{
    if (c == '(')
        pos += 1;
    else
        pos -= 1;
    
    if(pos == -1)
        break;
    index++;
}
System.Console.WriteLine(index);