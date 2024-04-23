using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ModularMonolith.Books.Entities;

[Index(nameof(Name), IsUnique = true)]
internal sealed class Author
{
    public Guid Id { get; init; }

    [StringLength(75)]
    public string Name { get; init; } = string.Empty;

    // Soft-Delete Implementation
    public bool IsDeleted { get; init; }

    //Auditing Fields
    public DateTime CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; set; }

    //Navigation Property
    public List<Book>? Books { get; init; }
}