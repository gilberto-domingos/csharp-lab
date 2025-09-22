using System;

public interface AdvancedArithmetic
{
    int DivisorSum(int number);
}

public class Calculator : AdvancedArithmetic
{
    public int DivisorSum(int number)
    {
        if (number <= 0) 
            throw new ArgumentException("O número deve ser positivo e maior que zero.");

        int sum = 0;
        int sqrt = (int)Math.Sqrt(number);

        for (int i = 1; i <= sqrt; i++)
        {
            if (number % i == 0)
            {
                sum += i;
                int other = number / i;
                if (other != i)
                    sum += other;
            }
        }
        return sum;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int n = ReadNumber();

        Calculator myCalculator = new Calculator();
        Console.WriteLine(myCalculator.DivisorSum(n));
    }

    private static int ReadNumber()
    {
        int number;

        while (true)
        {
            Console.Write("Digite um número inteiro positivo para saber a soma de seus divisores :");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out number) && number > 0)
                return number;

            Console.WriteLine("Entrada inválida. Por favor, digite um número inteiro maior que zero.\n");
        }
    }
}