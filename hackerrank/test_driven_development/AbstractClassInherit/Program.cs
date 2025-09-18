using System;

namespace HackerRank.AbstractClasses
{
    public abstract class Book
    {
        protected string Title { get; }
        protected string Author { get; }

        protected Book(string title, string author)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Author = author ?? throw new ArgumentNullException(nameof(author));
        }

        public abstract void Display();
    }

    public class MyBook : Book
    {
        private int Price { get; }

        public MyBook(string title, string author, int price)
            : base(title, author)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "O preço não pode ser negativo.");
            }

            Price = price;
        }

        public override void Display()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Price: {Price}");
        }
    }

    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Digite o título do livro:");
            string? title = Console.ReadLine();

            Console.WriteLine("Digite o autor do livro:");
            string? author = Console.ReadLine();

            Console.WriteLine("Digite o preço do livro:");
            if (!int.TryParse(Console.ReadLine(), out int price))
            {
                Console.WriteLine("Preço inválido. Digite um número inteiro.");
                return;
            }

            Book newBook = new MyBook(title!, author!, price);

            Console.WriteLine("\nInformações do livro:");
            newBook.Display();
        }
    }
}
