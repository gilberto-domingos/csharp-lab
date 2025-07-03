using System;

namespace ChainedEvents
{
    // define the delegate for the event handler
    public delegate void MyEventHandler(string value);

    class EventPublisher
    {
        private string TheVal;
        public event MyEventHandler ValueChanged;

        public event EventHandler<ObjChangedEventArgs> ObjChanged;

        public string Val
        {
            set
            {
                this.TheVal = value;

                ValueChanged?.Invoke(TheVal);

                ObjChanged?.Invoke(this, new ObjChangedEventArgs { PropChanged = "Val" });
            }
        }
    }

    class ObjChangedEventArgs : EventArgs
    {
        public string PropChanged;
    }

    class Program
    {
        static void Main(string[] args)
        {
            EventPublisher obj = new EventPublisher();

            obj.ValueChanged += new MyEventHandler(changeListener1);
            obj.ValueChanged += new MyEventHandler(changeListener2);

            obj.ValueChanged += delegate (string s)
            {
                Console.WriteLine("This came from the anonymous handler");
            };

            obj.ObjChanged += delegate (object sender, ObjChangedEventArgs e)
            {
                Console.WriteLine($"{sender.GetType()} had the {e.PropChanged} changed");
            };

            string str;
            do
            {
                Console.WriteLine("Enter a value: ");
                str = Console.ReadLine();
                if (!str.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    obj.Val = str;
                }
            } while (!str.Equals("exit", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("Goodbye!");
        }

        static void changeListener1(string value)
        {
            Console.WriteLine("The value changed to {0}", value);
        }

        static void changeListener2(string value)
        {
            Console.WriteLine("I also listen to the event, and got {0}", value);
        }
    }
}
