using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Y2021;

public class D07
{

    [Theory]
    [TestData("202107")]
    public void Part01(string[] data)
    {
        var instructions = data[0].Split(",").Select(x => int.Parse(x)).ToList();

        var val = instructions.Count / 2;

        var median = instructions.OrderBy(x => x).ElementAt(val);

        var result = instructions.Sum(x => Math.Abs(median - x));
        Assert.Equal(345197, result);
    }

    [Theory]
    [TestData("202107")]
    public void Part02(string[] data)
    {
        var instructions = data[0].Split(",").Select(x => int.Parse(x)).ToList();

        var results = new List<int>();
        for (int i = 1; i < instructions.Max()/2; i++)
        {
            int result = 0;
            foreach (var ins in instructions)
            {
                var diff = Math.Abs(ins - i);
                foreach (var x in Enumerable.Range(1, diff))
                {
                    result += x;
                }
            }
            results.Add(result);
        }

        Assert.Equal(96361606, results.Min());
    }
}