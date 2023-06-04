using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeTee.Infrastructure.Persistence.Npgsql.Data;
using OpenIddict.Validation;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using static OpenIddict.Abstractions.OpenIddictConstants;
using Microsoft.AspNetCore.Identity;
using ThreeTee.Core.Entities;

namespace ThreeTee.Infrastructure.Identity;
public static class Extensions
{
    public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<EntitiesContext>(options =>
        {
            options.UseNpgsql(connectionString);
            options.UseOpenIddict();
        });
        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole<Guid>>()
            .AddEntityFrameworkStores<EntitiesContext>()
            .AddDefaultTokenProviders();

        services.AddOpenIddict()
            .AddCore(options =>
            {
                options
                .UseEntityFrameworkCore()
                .UseDbContext<EntitiesContext>();
            })
            .AddServer(options =>
            {
                // Enable the token endpoint.
                options.SetTokenEndpointUris("connect/token");
                options.SetAuthorizationEndpointUris("/connect/authorize");

                // Enable the client credentials flow.
                options.AllowClientCredentialsFlow()
                        .AllowImplicitFlow()
                        .AllowAuthorizationCodeFlow()
                        .AllowPasswordFlow()
                        .AllowRefreshTokenFlow();

                options.AcceptAnonymousClients();

                options.RegisterScopes(Scopes.OfflineAccess, Scopes.OpenId, Scopes.Profile, Scopes.Email, Scopes.Phone, Scopes.Address, Scopes.Roles);

                // Register the signing and encryption credentials.
                options.AddDevelopmentEncryptionCertificate()
                       .AddDevelopmentSigningCertificate();

                // Register the ASP.NET Core host and configure the ASP.NET Core options.
                options.UseAspNetCore()
                       .EnableTokenEndpointPassthrough()
                       .EnableLogoutEndpointPassthrough()
                       .EnableAuthorizationEndpointPassthrough();
            })
            .AddValidation(options =>
            {
                // Import the configuration from the local OpenIddict server instance.
                options.UseLocalServer();

                // Register the ASP.NET Core host.
                options.UseAspNetCore();
            });
        return services;
    }
}
