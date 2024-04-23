using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ModularMonolith.Books.Contracts.Requests;
using ModularMonolith.Books.Data;
using ModularMonolith.Books.Entities;
using ModularMonolith.Shared.HelperTypes;

namespace ModularMonolith.Books.Features;

internal abstract class CreateBook
{

    public class Command : IRequest<Result<bool>>
    {
        public string Title { get; init; } = string.Empty;
        public DateTime DatePublished { get; init; }
        public List<string>? Authors { get; init; }
    }

    internal sealed class Handler(BooksDbContext context) : IRequestHandler<Command, Result<bool>>
    {
        public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                DatePublished = request.DatePublished,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow
            };

            if (request.Authors != null)
                book.Authors = request.Authors.Select(a => new Author
                {
                    Id = Guid.NewGuid(),
                    Name = a,
                    IsDeleted = false,
                    CreatedAt = DateTime.UtcNow
                }).ToList();

            context.Books.Add(book);

            await context.SaveChangesAsync(cancellationToken);


            return true;
        }
    }

}

public class CreateBookEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/book", async (CreateBookDto book, ISender sender) =>
        {
            var request = new CreateBook.Command
            {
                Title = book.Title,
                DatePublished = book.DatePublished,
                Authors = book.Authors.Select(a => a.Name).ToList()
            };

            var result = await sender.Send(request);
            return result.IsFailure ? Results.BadRequest(result.Error) : Results.Ok(result);
        });
    }
}