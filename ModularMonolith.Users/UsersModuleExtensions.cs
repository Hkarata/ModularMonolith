using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using ModularMonolith.Users.Data;

namespace ModularMonolith.Users;

public static class UsersModuleExtension
{
    public static IServiceCollection AddUsersModuleServices(
        this IServiceCollection services,
        ConfigurationManager configurationManager,
        List<Assembly> mediatRAssemblies
        )
    {
        services.AddDbContext<UsersDbContext>(options =>
            options.UseSqlServer(configurationManager.GetConnectionString("AppDbConnection")));
        return services;
    }
}