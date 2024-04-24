using System.ComponentModel.DataAnnotations;

namespace ModularMonolith.Users.Entities;

internal class User
{
    public Guid Id { get; init; }
    
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    
    // Auditing Fields
    public DateTime CreatedAt { get; init; }
    
    public DateTime UpdatedAt { get; set; }
    
    // Navigation Properties
    public UserAccount Account { get; set; } = null!;
}