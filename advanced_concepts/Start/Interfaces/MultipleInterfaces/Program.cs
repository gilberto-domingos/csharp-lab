// LinkedIn Learning Course exercise file for Advanced C# Programming by Joe Marini
// Example file for multiple interfaces

namespace MultipleInterfaces
{
    interface IStorable
    {
        void Save();
        void Load();
        Boolean NeedsSave { get; set; }
    }

    // TODO: Create an IEncryptable interface

    // TODO: Implement from both interfaces
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

        // TODO: Implement IEncryptable
    }

    class Program
    {
        static void Main(string[] args) {
            Document d = new Document("Test Document");

            // TODO: Exercise the interfaces

        }
    }
}

