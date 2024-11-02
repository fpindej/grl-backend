using GRL.Application.Services;
using GRL.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GRL.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICalendarService, CalendarService>();

        return services;
    }
}