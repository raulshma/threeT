using Microsoft.EntityFrameworkCore;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Extension;
using ThreeTee.Infrastructure.Persistence.Npgsql.Data;
using ThreeTee.Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("EntitiesContext");

builder.Services.AddAuthentication()
                .AddJwtBearer(config =>
                {
                    config.TokenValidationParameters.ValidateAudience = false;
                    config.TokenValidationParameters.ValidateIssuerSigningKey = true;
                    config.TokenValidationParameters.ValidateLifetime = true;
                    config.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(connectionString!.Substring(0, 32)));
                });
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ThreeTee",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
      new OpenApiSecurityScheme {
        Reference = new OpenApiReference {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer",
        }
      },
      new string[] {}
    }
  });
});

builder.Services.AddDistributedRedisCache(option =>
{
    option.Configuration = builder.Configuration["Redis"];
});
builder.Services.AddDbContext<EntitiesContext>(options =>
{
    options.UseNpgsql(connectionString);
});

builder.Services.AddHealthChecks()
    .AddDbContextCheck<EntitiesContext>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddApplicationServices();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);

});
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHealthChecks("/health");
app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
