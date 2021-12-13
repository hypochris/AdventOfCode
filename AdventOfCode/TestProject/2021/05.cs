using Helper;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Y2021;

public class D05
{
    private readonly ITestOutputHelper output;

    public D05(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Theory]
    [TestData("202105")]
    public void Part01(string[] data)
    {
        var entries = data.Select(x => x.Split(" -> "))
                         .Select(x => new { From = x[0], To = x[1] })
                         .Select(x => new
                         {
                             X1 = int.Parse(x.From.Split(",")[0]),
                             Y1 = int.Parse(x.From.Split(",")[1]),
                             X2 = int.Parse(x.To.Split(",")[0]),
                             Y2 = int.Parse(x.To.Split(",")[1])
                         })
                         .Select(x => new Entry(new Point(x.X1, x.Y1), new Point(x.X2, x.Y2))).ToList();

        var fromMaxX = entries.Select(x => x.From).Max(x => x.X);
        var toMaxX = entries.Select(x => x.To).Max(x => x.X);
        var fromMaxY = entries.Select(x => x.From).Max(x => x.Y);
        var toMaxY = entries.Select(x => x.To).Max(x => x.Y);

        var xMax = fromMaxX > toMaxX ? fromMaxX : toMaxX;
        var yMax = fromMaxY > toMaxY ? fromMaxY : toMaxY;

        var matrix = GenerateMatrix(xMax, yMax);

        entries = entries.Where(x => x.From.X == x.To.X || x.From.Y == x.To.Y).ToList();

        foreach (var entry in entries)
        {
            if (entry.From.X == entry.To.X)
            {
                var x = entry.From.X;
                var start = entry.From.Y < entry.To.Y ? entry.From.Y : entry.To.Y;
                var end = entry.From.Y > entry.To.Y ? entry.From.Y : entry.To.Y;
                for (var y = start; y <= end; y++)
                {
                    matrix[x, y]++;
                }
            }
            else
            {
                var y = entry.From.Y;
                var start = entry.From.X < entry.To.X ? entry.From.X : entry.To.X;
                var end = entry.From.X > entry.To.X ? entry.From.X : entry.To.X;
                for (var x = start; x <= end; x++)
                {
                    matrix[x, y]++;
                }
            }
        }

        var count = 0;
        for (var x = 0; x <= xMax; x++)
        {
            for (var y = 0; y <= yMax; y++)
            {
                if (matrix[x, y] > 1) count++;
            }
        }

        Assert.Equal(7438, count);
    }

    [Theory]
    [TestData("202105")]
    public void Part02(string[] data)
    {
        var entries = data.Select(x => x.Split(" -> "))
                         .Select(x => new { From = x[0], To = x[1] })
                         .Select(x => new
                         {
                             X1 = int.Parse(x.From.Split(",")[0]),
                             Y1 = int.Parse(x.From.Split(",")[1]),
                             X2 = int.Parse(x.To.Split(",")[0]),
                             Y2 = int.Parse(x.To.Split(",")[1])
                         })
                         .Select(x => new Entry(new Point(x.X1, x.Y1), new Point(x.X2, x.Y2))).ToList();

        var fromMaxX = entries.Select(x => x.From).Max(x => x.X);
        var toMaxX = entries.Select(x => x.To).Max(x => x.X);
        var fromMaxY = entries.Select(x => x.From).Max(x => x.Y);
        var toMaxY = entries.Select(x => x.To).Max(x => x.Y);

        var xMax = fromMaxX > toMaxX ? fromMaxX : toMaxX;
        var yMax = fromMaxY > toMaxY ? fromMaxY : toMaxY;

        var matrix = GenerateMatrix(xMax, yMax);

        foreach (var entry in entries)
        {
            var xDiff = ReturnMath(entry.From.X, entry.To.X);
            var yDiff = ReturnMath(entry.From.Y, entry.To.Y);

            var xPointer = entry.To.X;
            var yPointer = entry.To.Y;

            while(entry.From.X != xPointer || entry.From.Y != yPointer)
            {
                matrix[xPointer, yPointer]++;
                xPointer += xDiff;
                yPointer += yDiff;
            }
            matrix[xPointer, yPointer]++;
        }

        var count = 0;
        for (var x = 0; x <= xMax; x++)
        {
            for (var y = 0; y <= yMax; y++)
            {
                if (matrix[x, y] > 1) count++;
            }
        }

        Assert.Equal(21406, count);
    }


    private static int[,] GenerateMatrix(int xMax, int yMax)
    {
        int[,] matrix = new int[yMax + 1, xMax + 1];
        for (var x = 0; x < xMax + 1; x++)
        {
            for (var y = 0; y < yMax + 1; y++)
            {
                matrix[x, y] = 0;
            }
        }
        return matrix;
    }

    public static string Print2DArray(int[,] matrix)
    {
        var s = new StringBuilder();
        for (int y = 0; y < matrix.GetLength(0); y++)
        {
            for (int x = 0; x < matrix.GetLength(1); x++)
            {
                s.Append(matrix[x, y]).Append('\t');
            }
            s.Append("\r\n");
        }
        return s.ToString();
    }

    public static int ReturnMath(int a, int b)
    {
        var result = a - b;
        if (result == 0)
            return 0;
        else if (result > 0)
            return 1;
        else
            return -1;
    }
}

public record Point(int X, int Y);
public record Entry(Point From, Point To);