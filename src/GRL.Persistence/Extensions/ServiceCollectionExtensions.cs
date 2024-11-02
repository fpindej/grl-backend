using GRL.Domain.Repositories;
using GRL.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GRL.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GrlDbContext>(opt =>
        {
            var connectionString = configuration.GetConnectionString("Database");
            opt.UseNpgsql(connectionString);
        });

        services.AddScoped<ICalendarRepository, CalendarRepository>();

        return services;
    }
}