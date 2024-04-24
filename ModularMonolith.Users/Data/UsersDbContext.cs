using Microsoft.EntityFrameworkCore;
using ModularMonolith.Users.Entities;

namespace ModularMonolith.Users.Data;

public class UsersDbContext(DbContextOptions<UsersDbContext> options) : DbContext(options)
{
    
    internal DbSet<User> Users { get; set; }
    internal DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(a => a.Account)
            .WithOne(b => b.User)
            .HasForeignKey<UserAccount>(b => b.Id);
    }
}