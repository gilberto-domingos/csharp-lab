using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Informe quantos nomes e telefones vai adicionar");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite nome e telefone");
        var phoneBook = new Dictionary<string, string>();

        for (int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ');
            string name = parts[0];
            string number = parts[1];
            phoneBook[name] = number;
        }

        
        Console.WriteLine("Digite no nome da pessoa que você quer consultar o telefone");
        string query;
        while ((query = Console.ReadLine()) != null)
        {
            query = query.Trim();

            if (phoneBook.ContainsKey(query))
                Console.WriteLine($"{query}={phoneBook[query]}");
            else
                Console.WriteLine("Not found");
        }
    }
}