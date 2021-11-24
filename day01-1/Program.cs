var data = File.ReadAllText("data.txt");

var chars = data.ToCharArray();

var count = chars.Count(x => x == '(') - chars.Count(x => x == ')');

System.Console.WriteLine(count);