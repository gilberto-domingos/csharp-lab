class Program
{
    static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        int sqrtN = (int)Math.Sqrt(n);
        for (int i = 3; i <= sqrtN; i += 2)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Informe quantos números você vai digitar para saber se primos.Ok");
        bool validate = int.TryParse(Console.ReadLine(), out int number);
        if (!validate || number <= 0)
        {
            Console.WriteLine("Entrada inválida.");
            return;
        }

        for (int i = 0; i < number; i++)
        {
            Console.WriteLine($"Digite o {i + 1}º número");
            string valueInput = Console.ReadLine();
            bool validNumber = int.TryParse(valueInput, out int n);

            if (!validNumber)
            {
                Console.WriteLine("Entrada inválida, precisa ser número inteiro.");
                i--; 
                continue;
            }

            if (IsPrime(n))
                Console.WriteLine("O número é primo.");
            else
                Console.WriteLine("O número NÃO é primo.");
        }
    }
}