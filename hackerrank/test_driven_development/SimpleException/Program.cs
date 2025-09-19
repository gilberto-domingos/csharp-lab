class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite um número inteiro");
        string Input = Console.ReadLine();

        try
        {
            int value = int.Parse(Input);
            Console.WriteLine(Input);
        }
        catch(Exception ex)
        {
            Console.WriteLine("Bad String", ex);
        }
    }
}