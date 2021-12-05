var data = File.ReadAllLines("data.txt");

var curData = data;

foreach (var i in Enumerable.Range(0,data[0].Length))
{
    var challenge = curData.GroupBy(x => x[i]).OrderByDescending(x => x.Count()).ToDictionary(x => x.Key, x => x.Count());
    var winner = challenge.ElementAt(0).Value == challenge.ElementAt(1).Value? '1' : challenge.ElementAt(0).Key;
    curData = curData.Where(x => x[i] == winner).ToArray();

    if (curData.Length == 1) break;
}
var oxy = Convert.ToInt16(curData[0], 2);

curData = data;
foreach (var i in Enumerable.Range(0,data[0].Length))
{
    var challenge = curData.GroupBy(x => x[i]).OrderBy(x => x.Count()).ToDictionary(x => x.Key, x => x.Count());
    var winner = challenge.ElementAt(0).Value == challenge.ElementAt(1).Value? '0' : challenge.ElementAt(0).Key;
    curData = curData.Where(x => x[i] == winner).ToArray();

    if (curData.Length == 1) break;
}
var co = Convert.ToInt16(curData[0], 2);
System.Console.WriteLine($"{oxy}, {co} = {oxy * co}");