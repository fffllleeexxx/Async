using System;
using System.Diagnostics;
using System.Threading.Tasks;

Console.WriteLine("Введите количество строк:");
int rows = int.Parse(Console.ReadLine());

Console.WriteLine("Введите количество столбцов:");
int columns = int.Parse(Console.ReadLine());

int[,] array1 = new int[rows, columns];
int[,] array2 = new int[rows, columns];

Stopwatch stopwatch = new Stopwatch();

stopwatch.Start();
await FillArrayAsync(array1);
stopwatch.Stop();
Console.WriteLine($"Первый массив заполнен за {stopwatch.ElapsedMilliseconds} мс");

stopwatch.Restart();
await FillArrayAsync(array2);
stopwatch.Stop();
Console.WriteLine($"Второй массив заполнен за {stopwatch.ElapsedMilliseconds} мс");

Console.WriteLine("Первый массив:");
PrintArray(array1);

Console.WriteLine("Второй массив:");
PrintArray(array2);

static async Task FillArrayAsync(int[,] array)
{
    Random random = new Random();

    for (int i = 0; i < array.GetLength(0); i++)
    {
        await Task.Run(() =>
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = random.Next(10);
            }
        });
    }
}

static void PrintArray(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}
