// LinkedIn Learning Course exercise file for Advanced C# Programming by Joe Marini
// Example file for lambdas as delegates

namespace LambdaDelegates
{
    // define a delegate 
    public delegate void myEventHandler(string value);

    class MyClass
    {
        private string? theVal = null;
        public event myEventHandler? valueChanged; // no need to initialize to null, defaults to null

        public string Val
        {
            set
            {
                this.theVal = value;
                // when the value changes, fire the event
                this.valueChanged?.Invoke(theVal); // safe invocation
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();

            // TODO: Use a Lambda expression to define an event handler
            // Note that this is a statement lambda, due to use of { }

            string? str;
            do
            {
                Console.WriteLine("Enter a value, or 'exit' to exit:");
                str = Console.ReadLine();
                if (!str!.Equals("exit"))
                {
                    obj.Val = str;
                }
            } while (!str.Equals("exit"));

            Console.WriteLine("Goodbye!");
        }
    }
}