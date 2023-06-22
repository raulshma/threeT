using System.Reflection;
using FluentValidation;
using MediatR;
// using MapsterMapper;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //remove these services later
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IBillingTypeService, BillingTypeService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IStatusService, StatusService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IDesignationService, DesignationService>();
        services.AddScoped<IProjectUserService, ProjectUserService>();
        //

        // services.AddMapster();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

        });
        return services;
    }
}