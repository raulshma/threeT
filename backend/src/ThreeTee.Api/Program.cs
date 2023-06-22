using Microsoft.EntityFrameworkCore;
using ThreeTee.Application.Interfaces;
using ThreeTee.Infrastructure.Persistence.Npgsql.Data;
using ThreeTee.Infrastructure.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("EntitiesContext");

builder.Services.AddAuthentication()
                .AddJwtBearer(config =>
                {
                    config.TokenValidationParameters.ValidateAudience = false;
                    config.TokenValidationParameters.ValidateIssuerSigningKey = false;
                    config.TokenValidationParameters.ValidateLifetime = true;
                    config.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(connectionString!.Substring(0, 32)));
                });
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDistributedRedisCache(option =>
{
    option.Configuration = builder.Configuration["Redis"];
});
//Remove this later when all controllers are using mediatr
builder.Services.AddDbContext<DbContext, EntitiesContext>(options =>
{
    options.UseNpgsql(connectionString);
});
builder.Services.AddInfrastructurePersistenceServices(connectionString!);
builder.Services.AddApplicationServices();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
