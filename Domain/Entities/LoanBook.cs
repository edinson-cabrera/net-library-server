namespace library_server.Domain.Entities;

public class LoanBook
{
    public Guid LoanId { get; set; }
    public Loan Loan { get; set; }

    public Guid BookId { get; set; }
    public Book Book { get; set; }
    
}