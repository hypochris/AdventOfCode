var data = File.ReadAllLines("data.txt");

var total = 0;
foreach (var gift in data)
{
    var dim = gift.Split("x").Select(Int32.Parse).ToList();
    var l = dim[0];
    var w = dim[1];
    var h = dim[2];

    var s1 = l*w;
    var s2 = w*h;
    var s3 = h*l;

    var dimensions = (2*l*w + 2*w*h + 2*h*l);

    var smallest = new List<int>(){ s1, s2, s3}.OrderBy(x => x).ToList()[0];

    total += (dimensions + smallest);
}

System.Console.WriteLine(total);