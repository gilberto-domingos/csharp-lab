using System;
public class Printer
{ 
    public static void PrintArray<T>(T[] array, string title)
    {
        Console.WriteLine(title);
        foreach (T item in array)
            Console.WriteLine(item);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite 3 numeros inteiros");
        int[] numbers = new int[3];

        for (int i = 0; i < numbers.Length; i++)
        {
           Console.Write($"Digite o {i + 1}º número :");

            bool validate = int.TryParse(Console.ReadLine(), out int number);

            if (validate)
            {
                numbers[i] = number;
            }
            else
            {
                Console.WriteLine("Entrada inválida, digite números inteiros.");
            }
            
        }
        
        int[] ints = { 1, 2, 3, 4 };
        string[] words = { "olá", "mundo", "generics" };

        Printer.PrintArray(numbers, "Array definido pelo usuario :");
        Printer.PrintArray(ints,"Array de números já no sistema :");
        Printer.PrintArray(words,"Array de strings já no sistema :");
    }
}