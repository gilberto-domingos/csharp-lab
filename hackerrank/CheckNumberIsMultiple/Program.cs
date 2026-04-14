using System;

class Program
{
    static void fizzBuzz(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            string s = (i % 3 == 0 ? "Fizz" : "") + (i % 5 == 0 ? "Buzz" : "");
            Console.WriteLine(s == "" ? i.ToString() : s);
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Digite um numero para verificar se eles são múltiplos de 3 e 5.");
        int n = Convert.ToInt32(Console.ReadLine());
        fizzBuzz(n);
    }
}