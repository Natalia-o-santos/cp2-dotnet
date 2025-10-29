using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using FleetRental.Application.Mapping;
using FleetRental.Application.Services;
using FleetRental.Application.Services.Implementations;

namespace FleetRental.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddScoped<IRiderService, RiderService>();
        services.AddScoped<IMotorcycleService, MotorcycleService>();
        return services;
    }
}
