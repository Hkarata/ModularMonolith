using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ModularMonolith.Books.Data;

internal class BooksDbContextFactory : IDesignTimeDbContextFactory<BooksDbContext>
{
    public BooksDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BooksDbContext>();
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\\mssqllocaldb;Database=ModularMonolithDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        return new BooksDbContext(optionsBuilder.Options);
    }
}