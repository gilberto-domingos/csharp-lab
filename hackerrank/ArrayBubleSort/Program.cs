using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Informe quantos números você vai digitar, para ver a ordenação.");
        int n = int.Parse(Console.ReadLine());
        
        Console.WriteLine($"Digite os {n} números na mesma linha por espaços");
        string[] input = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(input, int.Parse);

        int totalSwaps = 0;

        for (int i = 0; i < n; i++)
        {
            int numberOfSwaps = 0;

            for (int j = 0; j < n - 1; j++)
            {
                if (a[j] > a[j + 1])
                {
                    int temp = a[j];
                    a[j] = a[j + 1];
                    a[j + 1] = temp;

                    numberOfSwaps++;
                    totalSwaps++;
                }
            }

            if (numberOfSwaps == 0)
            {
                break;
            }
        }

        Console.WriteLine($"Array está ordenado em {totalSwaps} swaps.");
        Console.WriteLine("Array ordenado: " + string.Join(" ", a));
        Console.WriteLine($"Primeiro elemento: {a[0]}");
        Console.WriteLine($"Ultimo elemento: {a[n - 1]}");
    }
}