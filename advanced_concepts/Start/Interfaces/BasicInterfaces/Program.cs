namespace BasicInterfaces
{
    interface IStorable
    {
        void Save();
        void Load();
        
        bool NeeSave { get; set; }
    }


    class Document : IStorable
    {
        private string name;

        public Document(string s)
        {
            name = s;
            Console.WriteLine("Created a document with name '{0}'", s);
        }

        public void Save()
        {
            Console.WriteLine("Saving the document");
        }

        public void Load()
        {
            Console.WriteLine("Loading the document");
        }

        public bool NeeSave { get; set; }
    }

    class Program
    {
        static void Main(string[] args) {
            Document d = new Document("Test Document");

            d.Save();
            d.Load();
            d.NeeSave = false;


        }
    }
}
