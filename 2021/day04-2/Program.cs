string[]? data = File.ReadAllLines("data.txt");
var numbers = data[0].Split(",").Select(x => int.Parse(x)).ToArray();

var boards = InitBoard(data);

for(var i = 0; i < numbers.Length; i++)
{
    var number = numbers[i];
    foreach (var board in boards)
    {
        for(int j = 0; j < board.Rows.Count(); j++)
        {
            var val = board.Rows.ElementAt(j).FirstOrDefault(x => x.Value == number) ?? board.Rows.Select(x => x.ElementAt(j)).FirstOrDefault(x => x.Value == number);
            if (val != null)
            {
                val.Found = true;
                var bingo = board.Rows.ElementAt(j).All(x => x.Found);
                if(bingo)
                {
                    board.Bingo = true;
                    var boardBingo = boards.All(x => x.Bingo);
                    if (boardBingo)
                    {
                        var score = board.Rows.SelectMany(x => x).Where(x => !x.Found).Select(x => x.Value).Sum();
                        System.Console.WriteLine(score * val.Value);
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}

static IEnumerable<Board> InitBoard(string[]? data)
{
    var boards = new List<Board>();
    var board = new Board();
    for(var i = 2; i < data?.Length; i++)
    {
        var row = new List<Field>();
        var dataRow = data[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
        for(var j = 0; j < 5; j++)
        {
            row.Add(new Field(){Value = int.Parse(dataRow[j]), Found = false});
        }
        board.Rows = board.Rows.Append(row);

        if(board.Rows.Count() == 5)
        {
            boards.Add(board);
            board = new Board();
            i++;
        }
    }
    return boards;
}

public class Board
{
    public IEnumerable<IEnumerable<Field>> Rows { get; set; } = new List<List<Field>>();
    public bool Bingo { get; set; }
}
public class Field
{
    public int Value { get; set; }
    public bool Found { get; set; }
}