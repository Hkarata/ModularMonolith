using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ModularMonolith.Books.Entities;

[Index(nameof(Title), IsUnique = true)]
internal sealed class Book
{
    public Guid Id { get; init; }

    [StringLength(100)]
    public string Title { get; init; } = string.Empty;

    // Soft-Delete Implementation
    public bool IsDeleted { get; init; }

    public DateTime DatePublished { get; init; }

    //Auditing Fields
    public DateTime CreatedAt { get; init; }

    public DateTime? UpdatedAt { get; set; }

    //Navigation Property
    public List<Author>? Authors { get; set; }
}