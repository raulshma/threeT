using System.Reflection;
using FluentValidation;
using Mapster;
using MapsterMapper;
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
        //Mapster
        var config = new TypeAdapterConfig();
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        //Fluent validation
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        //MediatR
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