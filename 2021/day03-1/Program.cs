var data = File.ReadAllLines("data.txt");

var gammaRate = "";
var epsilonRate = "";

foreach (var i in Enumerable.Range(0,data[0].Length))
{
    var order = data.GroupBy(x => x[i]).OrderByDescending(grp => grp.Count()).Select(x => x.Key);
    gammaRate += order.ElementAt(0);
    epsilonRate += order.ElementAt(1);
}

var gammaRateDec = Convert.ToInt32(gammaRate, 2);
var epsilonRateDec = Convert.ToInt32(epsilonRate, 2);

System.Console.WriteLine($"{gammaRateDec} - {epsilonRateDec} = {gammaRateDec * epsilonRateDec}");