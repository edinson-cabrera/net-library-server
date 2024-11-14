namespace library_server.Domain.Entities;

public class Loan
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime LoanDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
    
    private Loan() { }

    // Relación muchos a muchos con Book
    public ICollection<LoanBook> LoanBooks { get; private set; } = new List<LoanBook>();

    public Loan(Guid userId)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        LoanDate = DateTime.UtcNow;
    }

    public void MarkAsReturned()
    {
        ReturnDate = DateTime.UtcNow;
    }
}