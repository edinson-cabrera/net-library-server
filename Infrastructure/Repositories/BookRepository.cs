using library_server.Application.Interfaces;
using library_server.Domain.Entities;
using library_server.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace library_server.Infrastructure.Repositories;

public class BookRepository : IRepository<Book>
{
    private readonly LibraryDbContext _context;

    public BookRepository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task<Book> GetByIdAsync(Guid id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task AddAsync(Book entity)
    {
        await _context.Books.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Book entity)
    {
        _context.Books.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}