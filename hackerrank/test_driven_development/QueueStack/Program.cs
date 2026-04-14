class QueueStack
{
    public string? Word { get; set; }
    private Stack<Char> _stack = new Stack<char>();
    private Queue<Char> _queue = new Queue<char>();

    public QueueStack(){}
    
    public QueueStack(string word)
    {
        Word = word;
    }

    public void PushCharater(char ch)
    {
        _stack.Push(ch);
    }

    public void EnqueueCharater(char ch)
    {
        _queue.Enqueue(ch);
    }

    public char PopCharacter()
    {
        return _stack.Pop();
    }

    public char DequeueCharacter()
    {
        return _queue.Dequeue();
    }
}

class Program
{
    static void Main(string[] args)
    {
        QueueStack obj = new QueueStack();
        
        do
        {
            Console.WriteLine("Digite uma palavra para saber se é um palíndromo:");
            obj.Word = Console.ReadLine() ?? "";
        } 
        while (string.IsNullOrWhiteSpace(obj.Word));


        foreach (char character in obj.Word)
        {
            obj.PushCharater(character);
            obj.EnqueueCharater(character);
        }
        
        bool isPalindrome = true;

            for (int i = 0; i < obj.Word.Length / 2; i++)
            {
                if (obj.PopCharacter() != obj.DequeueCharacter())
                {
                    isPalindrome = false;
                    Console.Write($"{obj.Word} : Essa palavra não é um palíndromo");
                    break;
                }
                else
                {
                    Console.WriteLine($"{obj.Word} : A palavra é um palíndromo.");
                }
            }
    }
}
