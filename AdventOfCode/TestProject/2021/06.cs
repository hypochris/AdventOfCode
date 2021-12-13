using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Y2021;

public class D06
{
    private readonly ITestOutputHelper output;
    private const int days1 = 80;
    private const int days2 = 256;

    public D06(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Theory]
    [TestData("202106")]
    public void Part01(string[] data)
    {
        var fishes = data[0].Split(",").Select(x => int.Parse(x)).ToList();

        for (int i = 0; i < days1; i++)
        {
            var toAdd = new List<int>();
            for (int x = 0; x < fishes.Count; x++)
            {
                if (fishes[x] == 0)
                {
                    fishes[x] = 6;
                    toAdd.Add(8);
                }
                else
                {
                    fishes[x]--;
                }
            }
            fishes.AddRange(toAdd);
        }

        Assert.Equal(391671, fishes.Count);
    }

    [Theory]
    [TestData("202106")]
    public void Part02(string[] data)
    {
        var fishes = data[0].Split(",").Select(x => int.Parse(x)).ToList();

        var d = Init(fishes);

        for (long i = 0; i < days2; i++)
        {
            var zero = d[0];
            d[0] = 0;
            for (long x = 1;x < 9; x++)
            {
                d[x-1] = d[x];
            }
            d[8] = zero;
            d[6] += zero;
        }

        Assert.Equal(1754000560399, d.Sum(x => x.Value));
    }

    private static IDictionary<long, long> Init(IEnumerable<int> fishes)
    {
        var d = new Dictionary<long, long>()
        {
            {0, 0},
            {1, 0},
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0},
            {6, 0},
            {7, 0},
            {8, 0}
        };

        foreach (var fish in fishes)
        {
            d[fish]++;
        }
        return d;
    }
}