namespace ModularMonolith.Books.Contracts.Requests;

public record struct CreateBookDto(string Title, DateTime DatePublished, List<CreateAuthorDto> Authors);