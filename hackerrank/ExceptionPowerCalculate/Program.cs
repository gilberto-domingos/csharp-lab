using System;

class Calculator
{
    public int power(int n, int p)
    {
        if (n < 0 || p < 0)
            throw new Exception("n and p should be non-negative");

        int result = 1;
        for (int i = 0; i < p; i++)
            result *= n;

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Um teste calcula a potência entre 2 numeros. Digite o número de testes que você deseja fazer:");
        int T = int.Parse(Console.ReadLine()!);

        Calculator myCalculator = new Calculator();

        for (int i = 0; i < T; i++)
        {
            Console.WriteLine($"Teste #{i+1}: digite número1 e número2 separados por espaço:");
            string[] parts = Console.ReadLine()!.Trim().Split();
            int n = int.Parse(parts[0]);
            int p = int.Parse(parts[1]);

            try
            {
                int ans = myCalculator.power(n, p);
                Console.WriteLine($"Resultado : {ans}");
                Console.WriteLine($"Cálculo da potência de {n} e {p} = {ans}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine("Processamento concluído.");
    }
}