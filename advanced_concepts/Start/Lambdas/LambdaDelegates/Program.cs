namespace LambdaDelegates
{
    public delegate void myEventHandler(string value);

    class MyClass
    {
        private string? theVal = null;
        public event myEventHandler? valueChanged; 

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

            obj.valueChanged += (x) =>
            {
                Console.WriteLine($"The value changed to {x}");
            };
            

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