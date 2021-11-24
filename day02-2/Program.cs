var data = File.ReadAllLines("data.txt");

var total = 0;
foreach (var gift in data)
{
    var dim = gift.Split("x").Select(Int32.Parse).ToList();
    var l = dim[0];
    var w = dim[1];
    var h = dim[2];

    var order = new List<int>(){ l, w, h}.OrderBy(x => x).ToList();
    var first = order[0];
    var second = order[1];

    total += (l*w*h) + (first+first+second+second);
}

System.Console.WriteLine(total);