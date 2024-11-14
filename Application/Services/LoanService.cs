using library_server.Application.Interfaces;
using library_server.Domain.Entities;

namespace library_server.Application.Services;

public class LoanService
{
    private readonly IRepository<Loan> _loanRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IRepository<Book> _bookRepository;

    public LoanService(IRepository<Loan> loanRepository, IRepository<User> userRepository, IRepository<Book> bookRepository)
    {
        _loanRepository = loanRepository;
        _userRepository = userRepository;
        _bookRepository = bookRepository;
    }

    public async Task RegisterLoanAsync(Guid userId, List<Guid> bookIds)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new Exception("User not found.");

        var loan = new Loan(userId);

        foreach (var bookId in bookIds)
        {
            var book = await _bookRepository.GetByIdAsync(bookId);
            if (book == null)
                throw new Exception($"Book with ID {bookId} not found.");

            book.LendCopy();
            loan.LoanBooks.Add(new LoanBook { Loan = loan, Book = book });
        }

        await _loanRepository.AddAsync(loan);
    }
}