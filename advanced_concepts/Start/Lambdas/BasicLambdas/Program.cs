// LinkedIn Learning Course exercise file for Advanced C# Programming by Joe Marini
// Example file for basic lambda functions

namespace BasicLambdas
{
    // define a few delegate types
    public delegate int MyDelegate(int x);
    public delegate void MyDelegate2(int x, string prefix);
    public delegate bool ExprDelegate(int x);

    class Program
    {
        static void Main(string[] args)
        {
            // Create a basic delegate that squares a number
            MyDelegate func1 = (x) => x * x;
            Console.WriteLine("The result of foo is: {0}", func1(5));

            // Dynamically change the delegate to something else
            func1 = (x) => x * 10;
            Console.WriteLine("The result of bar is: {0}", func1(5));

            // Create a delegate that takes multiple arguments
            MyDelegate2 func2 = (x, y) => {
                Console.WriteLine("The two-arg lambda: {1}, {0}", x * 10, y);
            };
            func2(25, "Some string");

            // Define an expression delegate
            ExprDelegate func3 = (x) => x > 10;
            Console.WriteLine("Calling baz with 5: {0}", func3(5));
            Console.WriteLine("Calling bax with 15: {0}", func3(15));
        }
    }
}
