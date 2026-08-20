using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Treasury.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Treasury.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Add DbContext with PostgreSQL configuration.
        services.AddDbContext<TreasuryDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<TreasuryDbSeeder>();

        return services;
    }
}