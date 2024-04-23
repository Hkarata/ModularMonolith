using Microsoft.EntityFrameworkCore;
using ModularMonolith.Books.Entities;

namespace ModularMonolith.Books.Data;

public class BooksDbContext(DbContextOptions<BooksDbContext> options) : DbContext(options)
{
    internal DbSet<Author> Authors { get; set; }
    internal DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Books");
        base.OnModelCreating(modelBuilder);
    }
}