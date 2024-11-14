using library_server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace library_server.Infrastructure.Persistence;

public class LibraryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }
    public DbSet<LoanBook> LoanBooks { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoanBook>()
            .HasKey(lb => new { lb.LoanId, lb.BookId });

        modelBuilder.Entity<LoanBook>()
            .HasOne(lb => lb.Loan)
            .WithMany(l => l.LoanBooks)
            .HasForeignKey(lb => lb.LoanId);

        modelBuilder.Entity<LoanBook>()
            .HasOne(lb => lb.Book)
            .WithMany(b => b.LoanBooks)
            .HasForeignKey(lb => lb.BookId);
    }
}