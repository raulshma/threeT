using OpenIddict.Abstractions;
using ThreeTee.Infrastructure.Persistence.Npgsql.Data;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace ThreeTee.Authentication;
public class Worker : IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public Worker(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<EntitiesContext>();
        await context.Database.EnsureCreatedAsync();

        var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();


        var app = await manager.FindByClientIdAsync("threet-app");

        if (app is null)
        {
            await manager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "threet-app",
                DisplayName = "ThreeT Boom",
                Permissions =
                {
                    Permissions.Endpoints.Token,
                    Permissions.Endpoints.Authorization,
                    Permissions.Endpoints.Revocation,
                    Permissions.Endpoints.Logout,
                    Permissions.Endpoints.Introspection,
                    Permissions.Scopes.Roles,
                    Permissions.Scopes.Phone,
                    Permissions.Scopes.Profile,
                    Permissions.Scopes.Email,
                    Permissions.Scopes.Address,
                    Permissions.ResponseTypes.Code,
                    Permissions.ResponseTypes.Token,
                    Permissions.ResponseTypes.CodeIdToken,
                    Permissions.ResponseTypes.IdTokenToken,
                    Permissions.ResponseTypes.IdToken,
                    Permissions.GrantTypes.ClientCredentials,
                    Permissions.GrantTypes.AuthorizationCode,
                    Permissions.GrantTypes.Implicit,
                    Permissions.GrantTypes.RefreshToken,
                    Permissions.GrantTypes.Password,
                    Permissions.Prefixes.Scope + "ThreeTApp"
                },
                RedirectUris = { 
                    new Uri("http://localhost:3000"),
                    new Uri("http://localhost:3000/api/auth/callback/threet"),
                    new Uri("https://three-t.vercel.app"),
                    new Uri("https://three-t.vercel.app/api/auth/callback/threet"),
                }
            });
        }
        else
        {
            //remove the app on start
            await manager.DeleteAsync(app);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}