using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using ThreeTee.Core.Entities;

namespace ThreeTee.Infrastructure.Persistence.Npgsql.Data;

public class EntitiesContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public DbSet<BillingType> BillingTypes { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Designation> Designations { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectUser> ProjectUsers { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<UserDepartment> UserDepartments { get; set; }


    public EntitiesContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var systemTouchedBy = "System";

        var billingType = builder.Entity<BillingType>();
        billingType.HasIndex(e => e.Name);
        billingType.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        billingType.HasData(new BillingType
        {
            Id = Guid.NewGuid(),
            Name = "Upwork",
            CreatedAt = DateTime.UtcNow,
            LastTouchedBy = systemTouchedBy
        }, new BillingType
        {
            Id = Guid.NewGuid(),
            Name = "Wired",
            CreatedAt = DateTime.UtcNow,
            LastTouchedBy = systemTouchedBy
        }, new BillingType
        {
            Id = Guid.NewGuid(),
            Name = "Other",
            CreatedAt = DateTime.UtcNow,
            LastTouchedBy = systemTouchedBy
        });

        var client = builder.Entity<Client>();
        client.HasIndex(e => e.Name);
        client.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        var department = builder.Entity<Department>();
        department.HasIndex(e => e.Name);
        department.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        department.HasData(new Department
        {
            Id = Guid.NewGuid(),
            Name = "Dotnet",
            Code = ".net",
            CreatedAt = DateTime.UtcNow,
            LastTouchedBy = systemTouchedBy
        }, new Department
        {
            Id = Guid.NewGuid(),
            Name = "Quality Analyst",
            Code = "QA",
            CreatedAt = DateTime.UtcNow,
            LastTouchedBy = systemTouchedBy
        }, new Department
        {
            Id = Guid.NewGuid(),
            Name = "Business Analyst",
            Code = "BA",
            CreatedAt = DateTime.UtcNow,
            LastTouchedBy = systemTouchedBy
        });

        var designation = builder.Entity<Designation>();
        designation.HasIndex(e => e.Name);
        designation.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        designation.HasData(new Designation
        {
            Id = Guid.NewGuid(),
            Name ="Junior Software Engineer",
            CreatedAt = DateTime.UtcNow,
            LastTouchedBy = systemTouchedBy
        }, new Designation
        {
            Id = Guid.NewGuid(),
            Name = "Software Engineer",
            CreatedAt = DateTime.UtcNow,
            LastTouchedBy = systemTouchedBy
        }, new Designation
        {
            Id = Guid.NewGuid(),
            Name = "Senior Software Engineer",
            CreatedAt = DateTime.UtcNow,
            LastTouchedBy = systemTouchedBy
        }, new Designation
        {
            Id = Guid.NewGuid(),
            Name = "Team Leader",
            CreatedAt = DateTime.UtcNow,
            LastTouchedBy = systemTouchedBy
        }, new Designation
        {
            Id = Guid.NewGuid(),
            Name = "Junior Business Analyst",
            CreatedAt = DateTime.UtcNow,
            LastTouchedBy = systemTouchedBy
        }, new Designation
        {
            Id = Guid.NewGuid(),
            Name = "Business Analyst",
            CreatedAt = DateTime.UtcNow,
            LastTouchedBy = systemTouchedBy
        }, new Designation
        {
            Id = Guid.NewGuid(),
            Name = "Senior Business Analyst",
            CreatedAt = DateTime.UtcNow,
            LastTouchedBy = systemTouchedBy
        });

        var module = builder.Entity<Module>();
        module.HasIndex(e => e.Name);
        module.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        var profile = builder.Entity<Profile>();
        profile.HasIndex(e => e.Name);
        profile.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        var project = builder.Entity<Project>();
        project.HasIndex(e => e.Name);
        project.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        var projectUser = builder.Entity<ProjectUser>();
        projectUser.HasKey(e => new { e.UserId, e.ProjectId });
        projectUser.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        var status = builder.Entity<Status>();
        status.HasIndex(e => e.Description);
        status.HasIndex(e => e.DateFor);
        status.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        var userDepartment = builder.Entity<UserDepartment>();
        userDepartment.HasKey(e => new { e.UserId, e.DeparmentId });
        userDepartment.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");



    }
}
