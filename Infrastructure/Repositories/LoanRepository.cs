using library_server.Application.Interfaces;
using library_server.Domain.Entities;
using library_server.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace library_server.Infrastructure.Repositories;

public class LoanRepository : IRepository<Loan>
{
    private readonly LibraryDbContext _context;

    public LoanRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Loan entity)
    {
        await _context.Loans.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Loan> GetByIdAsync(Guid id)
    {
        return await _context.Loans.FindAsync(id);
    }

    public async Task<IEnumerable<Loan>> GetAllAsync()
    {
        return await _context.Loans.ToListAsync();
    }

    public async Task UpdateAsync(Loan entity)
    {
        _context.Loans.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var loan = await _context.Loans.FindAsync(id);
        if (loan != null)
        {
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
        }
    }
}