// LinkedIn Learning Course exercise file for Advanced C# Programmin by Joe Marini
// Example file for basic events

namespace BasicEvents
{
    public delegate void MyEventHandler(string value);

    class EventPublisher {
        private string TheVal = "";

        public event MyEventHandler ValueChanged;

        public string Val {
            set {
                this.TheVal = value;
                this.ValueChanged(TheVal);
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            EventPublisher obj = new EventPublisher();

            //obj.ValueChanged += new MyEventHandler(ObjValueChanged);

            obj.ValueChanged += delegate(string val)
            {
                Console.WriteLine($"The value changed to {val}");
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

        static void ObjValueChanged(string value) {
            Console.WriteLine("The value changed to {0}", value);
        }
    }
}
