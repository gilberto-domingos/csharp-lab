// LinkedIn Learning Course exercise file for Advanced C# Programming by Joe Marini
// Example file for chained events

namespace ChainedEvents
{
    // define the delegate for the event handler
    public delegate void MyEventHandler(string value);

    class MyClass
    {
        private string TheVal;
        // declare the event handler
        public event MyEventHandler ValueChanged;
        public event EventHandler<ObjChangeEventArgs> ObjChanged;

        public string Val
        {
            set
            {
                this.TheVal = value;
                // when the value changes, fire the event
                this.ValueChanged(TheVal);
                this.ObjChanged(this, new ObjChangeEventArgs() { PropChanged = "Val" });
            }
        }
    }

    class ObjChangeEventArgs : EventArgs
    {
        public string PropChanged;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // create the test class
            MyClass obj = new MyClass();
            // Connect multiple event handlers
            obj.ValueChanged += new MyEventHandler(ChangeListener1);
            obj.ValueChanged += new MyEventHandler(ChangeListener2);

            // Use an anonymous delegate as the event handler
            obj.ValueChanged += delegate(string s) {
                Console.WriteLine("This came from the anonymous handler!");
            };

            obj.ObjChanged += delegate(object sender, ObjChangeEventArgs e) {
                Console.WriteLine("{0} had the '{1}' property changed", sender.GetType(), e.PropChanged);
            };

            string str;
            do {
                Console.WriteLine("Enter a value: ");
                str = Console.ReadLine();
                if (!str.Equals("exit")) {
                    obj.Val = str;
                }
            } while (!str.Equals("exit"));
            Console.WriteLine("Goodbye!");
        }

        static void ChangeListener1(string value)
        {
            Console.WriteLine("The value changed to {0}", value);
        }
        static void ChangeListener2(string value)
        {
            Console.WriteLine("I also listen to the event, and got {0}", value);
        }
    }
}
