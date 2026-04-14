using System;

class Difference
{
    private int[] elements;
    public int maximumDifference;
    public int min;
    public int max;

    
    public Difference(int[] elements)
    {
        this.elements = elements;
    }

    
    public void computeDifference()
    {
         min = int.MaxValue;
         max = int.MinValue;

        foreach (int num in elements)
        {
            if (num < min) min = num;
            if (num > max) max = num;
        }

        
        maximumDifference = max - min;
    }
}

class Solution {
    static void Main(string[] args) {
        Console.WriteLine("Diga quantos numeros você vai digitar para saber a diferença absoluta, min, max.");
        Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Digite todos os números em uma única linha, separados por espaço:");
        int[] a = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

        Difference d = new Difference(a);

        d.computeDifference();
         
        Console.WriteLine($"Mínimo : {d.min}");
        Console.WriteLine($"Máximo : {d.max}");
        Console.WriteLine($"$ {d.max} - {d.min}");
        Console.Write($"Resultado : {d.maximumDifference}");
    }
}
