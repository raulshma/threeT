using Microsoft.Extensions.DependencyInjection;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Services;

namespace ThreeTee.Application.Extension;

public static class Extension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IBillingTypeService, BillingTypeService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IStatusService, StatusService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IDesignationService, DesignationService>();
        services.AddScoped<IProjectUserService, ProjectUserService>();
        return services;
    }
}
