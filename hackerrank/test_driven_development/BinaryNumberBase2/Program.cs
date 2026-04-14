using System;

class Program {
    static void Main() {
        Console.WriteLine("Digite um número inteiro para verificar a maior sequência de 1s consecutivos no binário:");
        int n = Convert.ToInt32(Console.ReadLine());
        string binary = Convert.ToString(n, 2);

        int maxCount = 0, currentCount = 0;
        foreach (char c in binary) {
            if (c == '1') {
                currentCount++;
                if (currentCount > maxCount) maxCount = currentCount;
            } else {
                currentCount = 0;
            }
        }
        Console.WriteLine(maxCount);
    }
}