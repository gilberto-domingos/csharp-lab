/* "objetivo é calcular todas as hourglass sums e imprimir apenas o valor máximo exemplo de entrada, abaixo"
1 1 1 0 0 0
0 1 0 0 0 0
1 1 1 0 0 0
0 0 2 4 4 0
0 0 0 2 0 0
0 0 1 2 4 0
*/

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Digite 6 linhas, cada linha contendo 6 números inteiros separados por espaço. Após digitar a sexta linha, pressione Enter para ver o resultado.[exemplo acima comentado]");
        List<List<int>> arr = new List<List<int>>();
        for (int i = 0; i < 6; i++)
        {
            arr.Add(Console.ReadLine()
                .TrimEnd()
                .Split(' ')
                .Select(int.Parse)
                .ToList());
        }

        int maxSum = Enumerable.Range(0, 4)
            .SelectMany(i => Enumerable.Range(0, 4),
                (i, j) => arr[i][j] + arr[i][j + 1] + arr[i][j + 2]
                          + arr[i + 1][j + 1]
                          + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2])
            .Max();

        Console.WriteLine(maxSum);
    }
}