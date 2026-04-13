using System;
using CodeChallenge;

namespace YourProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Hello World!";

            StringTransformer.Mode = "UPPER";
            Console.WriteLine("UPPER: " + StringTransformer.TransformString(input));

            StringTransformer.Mode = "LOWER";
            Console.WriteLine("LOWER: " + StringTransformer.TransformString(input));

            StringTransformer.Mode = "REVERSE";
            Console.WriteLine("REVERSE: " + StringTransformer.TransformString(input));
            
        }
    }
}