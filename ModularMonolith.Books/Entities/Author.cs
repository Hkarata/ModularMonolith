using System.ComponentModel.DataAnnotations;

namespace ModularMonolith.Books.Entities;

internal sealed class Author
{
    public Guid Id { get; init; }

    [StringLength(75)]
    public string Name { get; set; } = string.Empty;

    // Soft-Delete Implementation
    public bool IsDeleted { get; set; }

    //Auditing Fields
    public DateTime CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; set; }

    //Navigation Property
    public List<Book>? Books { get; set; }
}