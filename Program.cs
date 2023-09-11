using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введiть кiлькiсть елементiв масиву N:");
        if (!int.TryParse(Console.ReadLine(), out int N) || N <= 0)
        {
            Console.WriteLine("Невiрне значення N.");
            return;
        }

        Console.WriteLine("Введiть кiлькiсть елементiв M:");
        if (!int.TryParse(Console.ReadLine(), out int M) || M <= 0 || M > N)
        {
            Console.WriteLine("Невiрне значення M.");
            return;
        }

        int[] x = new int[N];

        Console.WriteLine("Введiть елементи масиву x:");

        for (int i = 0; i < N; i++)
        {
            Console.Write("x[{0}]: ", i);
            if (!int.TryParse(Console.ReadLine(), out x[i]) || x[i] < 0 || x[i] > 255)
            {
                Console.WriteLine("Невiрне значення x[{0}]. Введiть цiле число в межах [0, 255].", i);
                i--;
            }
        }

        int[] minSumElements = CalculateMinSumElements(x, M);

        Console.WriteLine("Мiнiмальне значення серед сум розташованих поруч {0} елементiв масиву: {1}", M, minSumElements[0]);
        Console.WriteLine("Елементи, якi утворюють мiнiмальну суму:");

        for (int i = 1; i <= M; i++)
        {
            Console.WriteLine("x[{0}] = {1}", minSumElements[i], x[minSumElements[i]]);
        }
    }

    static int[] CalculateMinSumElements(int[] x, int M)
    {
        int minSum = int.MaxValue;
        int[] minSumElements = new int[M + 1];

        for (int i = 0; i <= x.Length - M; i++)
        {
            int sum = 0;
            for (int j = i; j < i + M; j++)
            {
                sum += x[j];
            }
            if (sum < minSum)
            {
                minSum = sum;
                for (int k = 0; k < M; k++)
                {
                    minSumElements[k + 1] = i + k;
                }
            }
        }

        minSumElements[0] = minSum;
        return minSumElements;
    }
}