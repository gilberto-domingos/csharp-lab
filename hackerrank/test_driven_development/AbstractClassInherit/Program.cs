using System;

abstract class Book
{
    protected string title;
    protected string author;

    public Book(string t, string a)
    {
        title = t;
        author = a;
    }

    public abstract void display();
}

class MyBook : Book
{
    private int price;

    public MyBook(string title, string author, int price) 
        : base(title, author)
    {
        this.price = price;
    }

    public override void display()
    {
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Author: " + author);
        Console.WriteLine("Price: " + price);
    }
}

class Solution
{
    static void Main(string[] args)
    {
        string title = Console.ReadLine();
        string author = Console.ReadLine();
        int price = Int32.Parse(Console.ReadLine());

        Book new_novel = new MyBook(title, author, price);
        new_novel.display();
    }
}