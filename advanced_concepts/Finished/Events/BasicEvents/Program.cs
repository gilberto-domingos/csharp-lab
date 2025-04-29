// LinkedIn Learning Course exercise file for Advanced C# Programming by Joe Marini
// Example file for basic events

namespace BasicEvents
{
    // define the delegate for the event handler
    public delegate void MyEventHandler(string value);

    class EventPublisher
    {
        private string TheVal = "";

        // declare the event
        public event MyEventHandler ValueChanged;

        public string Val
        {
            set
            {
                this.TheVal = value;
                // when the value changes, fire the event
                this.ValueChanged(TheVal);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // use a named function as an event handler
            EventPublisher obj = new EventPublisher();
            obj.ValueChanged += new MyEventHandler(ObjValueChanged);

            // use an anonymous delegate as an event handler
            obj.ValueChanged += delegate(string val) {
                Console.WriteLine("The value changed to {0}", val);
            };

            string? str = "";
            do {
                Console.WriteLine("Enter a value: ");
                str = Console.ReadLine();
                if (!str!.Equals("exit")) {
                    obj.Val = str;
                }
            } while (!str.Equals("exit"));
            Console.WriteLine("Goodbye!");
        }

        static void ObjValueChanged(string value)
        {
            Console.WriteLine("The value changed to {0}", value);
        }
    }
}
