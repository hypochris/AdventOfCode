var data = File.ReadAllLines("data.txt");
const int size = 1000;

var matrix = GenerateMatrix();

foreach (var line in data)
{
    var ins = line.Split(" ");

    switch (ins[0])
    {
        case "toggle":
            {
                matrix = Toggle(matrix,
                                Array.ConvertAll(ins[1].Split(","), int.Parse),
                                Array.ConvertAll(ins[3].Split(","), int.Parse));
                break;
            }

        case "turn":
            {
                if (ins[1] == "on")
                {
                    matrix = On(matrix,
                                   Array.ConvertAll(ins[2].Split(","), int.Parse),
                                   Array.ConvertAll(ins[4].Split(","), int.Parse));
                }
                else if (ins[1] == "off")
                {
                    matrix = Off(matrix,
                                Array.ConvertAll(ins[2].Split(","), int.Parse),
                                Array.ConvertAll(ins[4].Split(","), int.Parse));
                }
                break;
            }
    }
}

Count(matrix);

static int[,] Toggle(int[,] matrix, int[] from, int[] to)
{
    for (int i = from[0]; i < to[0] + 1; i++)
    {
        for (int j = from[1]; j < to[1] + 1; j++)
        {
            if(matrix[i,j] == 0)
                matrix[i,j] = 1;
            else
                matrix[i,j] = 0;
        }
    }
    return matrix;
}

static int[,] On(int[,] matrix, int[] from, int[] to)
{
    for (int i = from[0]; i < to[0] + 1; i++)
    {
        for (int j = from[1]; j < to[1] + 1; j++)
        {
            matrix[i,j] = 1;
        }
    }
    return matrix;
}
static int[,] Off(int[,] matrix, int[] from, int[] to)
{
    for (int i = from[0]; i < to[0] + 1; i++)
    {
        for (int j = from[1]; j < to[1] + 1; j++)
        {
            matrix[i,j] = 0;
        }
    }
    return matrix;
}

static int[,] GenerateMatrix()
{
    var matrix = new int [size, size];

    for(var i = 0; i < size; i++)
    {
        for(int j = 0; j < size; j++)
        {
            matrix[i,j] = 0;
        }
    }

    return matrix;
}

static void Count(int[,] matrix)
{
    var count = 0;
    for(var i = 0; i < size; i++)
    {
        for(int j = 0; j < size; j++)
        {
            if(matrix[i,j] == 1)
                count++;
        }
    }
    System.Console.WriteLine(count);
}

