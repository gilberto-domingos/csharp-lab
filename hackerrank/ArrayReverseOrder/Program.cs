using System;

class Solution
{
    static void Main(string[] args)
    {
       int[] arrayx = new int[5];

       for (int i = 0; i < arrayx.Length; i++)
       {
           arrayx[i] = i + 1;
       }

       List<int> ArrayList = new List<int>(arrayx);
       
       Console.WriteLine("Elements of list");
       foreach (int num in ArrayList)
       {
           Console.WriteLine($"{num}");
       }

       Console.WriteLine("Print reverse");
       ArrayList.Reverse();
       foreach (int num in ArrayList)
       {
           Console.WriteLine($"{num}");
       }
    }
}