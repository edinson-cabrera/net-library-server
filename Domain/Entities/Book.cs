namespace library_server.Domain.Entities;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int CopiesAvailable { get; private set; }
    
    private Book() { }
    
    public ICollection<LoanBook> LoanBooks { get; private set; } = new List<LoanBook>();

    public Book(string title, string author, string isbn, int copiesAvailable)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        ISBN = isbn;
        CopiesAvailable = copiesAvailable;
    }

    public void LendCopy()
    {
        if (CopiesAvailable <= 0)
            throw new Exception("No copies available.");

        CopiesAvailable--;
    }

    public void ReturnCopy()
    {
        CopiesAvailable++;
    }
}