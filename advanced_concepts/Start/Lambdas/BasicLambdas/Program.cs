// LinkedIn Learning Course exercise file for Advanced C# Programming by Joe Marini
// Example file for basic lambda functions

namespace BasicLambdas
{
    public delegate int MyDelegate(int x);
    public delegate void MyDelegate2(int x, string prefix);

    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate func1 = (x) => x * x;
            Console.WriteLine($"The result of func1 is: {func1(5)}");

            func1 = (x) => x * 10;
            Console.WriteLine($"The result of func1 is: {func1(5)}");

            MyDelegate2 func2 = (x, y) =>
            {
                Console.WriteLine($"The two-arg lambda: {y}:{x * 10}");
            };
            func2(25, "Some string");

        }
    }
}
