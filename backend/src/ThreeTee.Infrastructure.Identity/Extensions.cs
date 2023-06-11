using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using ThreeTee.Infrastructure.Persistence.Npgsql.Data;
using static OpenIddict.Abstractions.OpenIddictConstants;
using Microsoft.AspNetCore.Identity;
using ThreeTee.Core.Entities;
using Microsoft.IdentityModel.Tokens;

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

                options.DisableAccessTokenEncryption();

                // Register the signing and encryption credentials.
                //options.AddDevelopmentEncryptionCertificate()
                //.AddDevelopmentSigningCertificate();
                options.AddEphemeralSigningKey();
                var keyBytes = Encoding.UTF8.GetBytes(connectionString.Substring(0, 32));
                options.AddEncryptionKey(new SymmetricSecurityKey(keyBytes));
                options.AddSigningKey(new SymmetricSecurityKey(keyBytes));

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
