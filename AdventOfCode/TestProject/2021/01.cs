using Helper;
using System.Linq;
using Xunit;

namespace Y2021;

public class D01
{
    [Theory]
    [TestData("202101")]
    public void Part01(string[] data)
    {
        var dataInt = data.Select(x => int.Parse(x.Trim())).ToArray();

        var count = 0;
        for (int i = 0; i < dataInt.Length - 1; i++)
        {
            if (dataInt[i] < dataInt[i + 1])
                count++;
        }

        Assert.Equal(1466, count);
    }

    [Theory]
    [TestData("202101")]
    public void Part02(string[] data)
    {
        var dataInt = data.Select(x => int.Parse(x.Trim())).ToArray();

        var count = 0;
        for (int i = 0; i < dataInt.Length - 3; i++)
        {
            var a = dataInt[i] + dataInt[i + 1] + dataInt[i + 2];
            var b = dataInt[i + 1] + dataInt[i + 2] + dataInt[i + 3];

            if (a < b)
                count++;
        }
        Assert.Equal(1491, count);
    }
}