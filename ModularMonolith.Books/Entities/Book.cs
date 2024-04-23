using System.ComponentModel.DataAnnotations;

namespace ModularMonolith.Books.Entities;

internal sealed class Book
{
    public Guid Id { get; init; }

    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    // Soft-Delete Implementation
    public bool IsDeleted { get; set; }

    public DateTime DatePublished { get; init; }

    //Auditing Fields
    public DateTime CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; set; }

    //Navigation Property
    public List<Author>? Authors { get; set; }
}