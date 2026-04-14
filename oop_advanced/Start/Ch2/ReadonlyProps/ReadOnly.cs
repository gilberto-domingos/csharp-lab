public class Book
{
    private readonly string _isbn;
    private string _title;
    private string _author;

    public Book(string isbn, string title, string author)
    {
        _isbn = isbn;
        _title = title;
        _author = author;
    }

    public void Update(string newIsbn, string newTitle, string newAuthor)
    {
       // _isbn = newIsbn;
        _title = newTitle;
        _author = newAuthor;
    }

    public override string ToString()
    {
        return $"{_isbn}: {_title} by {_author}";
    }
}