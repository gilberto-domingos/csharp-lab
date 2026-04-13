// LinkedIn Learning Course exercise file for Advanced C# Programming by Joe Marini
// Example file for casting interfaces

namespace CastingInterfaces
{
    interface IStorable
    {
        void Save();
        void Load();
        Boolean NeedsSave { get; set; }
    }

    class Document : IStorable
    {
        private string name;

        public Document(string s) {
            name = s;
            Console.WriteLine("Created a document with name '{0}'", s);
        }

        public void Save() {
            Console.WriteLine("Saving the document");
        }

        public void Load() {
            Console.WriteLine("Loading the document");
        }

        public Boolean NeedsSave {
            get; set;
        }
    }

    class Program
    {
        static void Main(string[] args) {
            Document d = new Document("Test Document");

            if (d is IStorable)
            {
                d.Save();
            }

            IStorable istor = d as IStorable;
            if (istor != null)
            {
                istor.Load();
            }

        }
    }
}
