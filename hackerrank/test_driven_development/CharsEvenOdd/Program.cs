/* Conhecimento sobre strings, combinando-o com loops */
/* Entrada :
 1
 HackerRank
 
 / Saída:  Hce akr Rn ak */
   

using System;
using System.Text;

class Program {
    static void Main(string[] args) {
        int T = int.Parse(Console.ReadLine());

        for (int t = 0; t < T; t++) {
            string s = Console.ReadLine();

            StringBuilder evenChars = new StringBuilder();
            StringBuilder oddChars = new StringBuilder();

            for (int i = 0; i < s.Length; i++) {
                if (i % 2 == 0)
                    evenChars.Append(s[i]);
                else
                    oddChars.Append(s[i]);
            }
            Console.WriteLine($"{evenChars} {oddChars}");
        }
    }
}
