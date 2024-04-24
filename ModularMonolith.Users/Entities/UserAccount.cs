using System.ComponentModel.DataAnnotations;

namespace ModularMonolith.Users.Entities;

internal class UserAccount
{
    public Guid Id { get; init; }
    
    [MaxLength(12)]
    public string Username { get; set; } = string.Empty;
    
    public string Password { get; set; } = string.Empty;
    
    // Auditing Fields
    public DateTime CreatedAt { get; init; }
    
    public DateTime UpdatedAt { get; set; }
    public User User { get; set; } = null!;
}