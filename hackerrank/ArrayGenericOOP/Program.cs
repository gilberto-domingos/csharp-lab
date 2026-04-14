using System;

public class ArrayGeneric
{
    public static void PrintArray<T>(T[] array, string title)
    {
        Console.WriteLine(title);
        
        foreach (T item in array)
        {
            Console.WriteLine(item);
        }
            
    }
}

public class InputHandler
{
    public int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;

            Console.WriteLine("Entrada inválida! Digite um número inteiro.");
        }
    }
}

public class NumberArray
{
    private int[] numbers;

    public NumberArray(int size)
    {
        numbers = new int[size];
    }

    public void PutNumbersIntoArray(InputHandler input)
    {
        for (int i = 0; i < numbers.Length; i++ )
        {
            int number = input.ReadInt($"Digite o {i + 1}º número: ");
            numbers[i] = number;
        }
    }

    public int[] GetNumbersOfArray()
    {
        return numbers;
    }
}

class Program
{
    static void Main(string[] args)
    {
        InputHandler input = new InputHandler();
        NumberArray userNumbers = new NumberArray(3);

        Console.WriteLine("Digite 3 números inteiros:");
        userNumbers.PutNumbersIntoArray(input);

        int[] systemNumbers = { 1, 2, 3, 4 };
        string[] words = { "olá", "mundo", "generics" };

        ArrayGeneric.PrintArray(userNumbers.GetNumbersOfArray(), "Array definido pelo usuário:");
        ArrayGeneric.PrintArray(systemNumbers, "Array de números já no sistema:");
        ArrayGeneric.PrintArray(words, "Array de strings já no sistema:");
    }
}