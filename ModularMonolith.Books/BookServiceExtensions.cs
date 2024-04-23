using Carter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Books.Data;
using System.Reflection;

namespace ModularMonolith.Books;

public static class BookServiceExtensions
{
    public static IServiceCollection AddBookModuleServices(
        this IServiceCollection services,
        ConfigurationManager configurationManager,
        List<Assembly> mediatRAssemblies)
    {
        services.AddDbContext<BooksDbContext>(options =>
            options.UseSqlServer(configurationManager.GetConnectionString("AppDbConnection")));
        services.AddCarter();
        mediatRAssemblies.Add(typeof(BookServiceExtensions).Assembly);
        //logger.LogInformation("{Module} module has been registered", "Books");
        return services;
    }
}