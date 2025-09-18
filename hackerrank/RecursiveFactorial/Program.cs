using System;

class Program
{
    static int factorial(int n)
    {
        if (n <= 1)
            return 1;

        return n * factorial(n - 1);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Digite um número inteiro para saber o fatorial e aperte enter.");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(factorial(n));
    }
}