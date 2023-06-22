using Microsoft.EntityFrameworkCore;
using ThreeTee.Infrastructure.Persistence.Npgsql.Data;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructurePersistenceServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<IEntitiesContext, EntitiesContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        return services;
    }
}