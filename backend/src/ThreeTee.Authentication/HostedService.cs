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

        if (await manager.FindByClientIdAsync("apiserver") is null)
        {
            await manager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "apiserver",
                ClientSecret = "388D45FA-B36B-4988-BA59-B187D329C207",
                DisplayName = "API Server",
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
                    Permissions.ResponseTypes.Token,
                    Permissions.ResponseTypes.CodeIdToken,
                    Permissions.ResponseTypes.CodeIdToken,
                    Permissions.ResponseTypes.IdTokenToken,
                    Permissions.ResponseTypes.IdToken,
                    Permissions.GrantTypes.ClientCredentials,
                    Permissions.GrantTypes.RefreshToken,
                    Permissions.GrantTypes.Password,
                    Permissions.Prefixes.Scope + "Authentication"
                }
            });
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}