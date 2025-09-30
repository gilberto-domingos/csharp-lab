using System;
using System.Globalization;

class Solution {
    static void Main(string[] args) {
        CultureInfo br = new CultureInfo("pt-BR");

        Console.WriteLine("Digite a data em que o livro foi devolvido (dd/MM/yyyy):");
        DateTime returnedDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", br);

        Console.WriteLine("Agora digite a data em que o livro deveria ser devolvido (dd/MM/yyyy):");
        DateTime dueDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", br);

        int returnDay = returnedDate.Day;
        int returnMonth = returnedDate.Month;
        int returnYear = returnedDate.Year;

        int dueDay = dueDate.Day;
        int dueMonth = dueDate.Month;
        int dueYear = dueDate.Year;

        int fine = 0;

        if (returnYear > dueYear) {
            fine = 10000;
        }
        else if (returnYear == dueYear) {
            if (returnMonth > dueMonth) {
                fine = 500 * (returnMonth - dueMonth);
            }
            else if (returnMonth == dueMonth && returnDay > dueDay) {
                fine = 15 * (returnDay - dueDay);
            }
        }

        
        Console.WriteLine(fine.ToString("C", br));
    }
}