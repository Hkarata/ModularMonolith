using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ModularMonolith.Users.Data;
using ModularMonolith.Users.Services;

namespace ModularMonolith.Users;

public static class UsersModuleExtensions
{
    public static IServiceCollection AddUsersModuleServices(
        this IServiceCollection services,
        ConfigurationManager configurationManager,
        List<Assembly> mediatRAssemblies
        )
    {
        services.AddDbContext<UsersDbContext>(options =>
            options.UseSqlServer(configurationManager.GetConnectionString("AppDbConnection")));
        
        services.AddScoped<PasswordService>();
        
        return services;
    }
}