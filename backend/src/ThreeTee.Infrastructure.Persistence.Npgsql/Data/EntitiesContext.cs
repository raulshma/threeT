using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
    public DbSet<DepartmentManager> DepartmentManagers { get; set; }

    public EntitiesContext(DbContextOptions options) : base(options)
    {
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
            }
        }

        return base.SaveChanges();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var systemTouchedBy = "System";

        var createdAt = DateTime.SpecifyKind(DateTime.Parse("2023-06-04T16:55:44.501Z"), DateTimeKind.Utc);

        var billingType = builder.Entity<BillingType>();
        billingType.HasIndex(e => e.Name);
        billingType.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        billingType.HasData(new BillingType
        {
            Id = Guid.Parse("dc53bb89-bb11-449b-96c2-5c7ac4d4bcd2"),
            Name = "Upwork",
            CreatedAt = createdAt,
            LastTouchedBy = systemTouchedBy
        }, new BillingType
        {
            Id = Guid.Parse("2fded05b-635f-4889-b263-6ec1922d95fb"),
            Name = "Wired",
            CreatedAt = createdAt,
            LastTouchedBy = systemTouchedBy
        }, new BillingType
        {
            Id = Guid.Parse("6e6027f9-f685-47c8-a1fe-43c32a620014"),
            Name = "Other",
            CreatedAt = createdAt,
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
            Id = Guid.Parse("e5c7e9ec-d1c2-441d-a4dc-253cdf766707"),
            Name = "Dotnet",
            Code = ".net",
            CreatedAt = createdAt,
            LastTouchedBy = systemTouchedBy
        }, new Department
        {
            Id = Guid.Parse("53691279-ef76-4054-8c2f-e28f6028f16d"),
            Name = "Quality Analyst",
            Code = "QA",
            CreatedAt = createdAt,
            LastTouchedBy = systemTouchedBy
        }, new Department
        {
            Id = Guid.Parse("143b0f1f-beb6-4e6b-a26b-1dd307dd6306"),
            Name = "Business Analyst",
            Code = "BA",
            CreatedAt = createdAt,
            LastTouchedBy = systemTouchedBy
        });

        var designation = builder.Entity<Designation>();
        designation.HasIndex(e => e.Name);
        designation.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

        designation.HasData(new Designation
        {
            Id = Guid.Parse("a0b3df08-e63a-4914-a576-6287a940b035"),
            Name = "Junior Software Engineer",
            CreatedAt = createdAt,
            LastTouchedBy = systemTouchedBy
        }, new Designation
        {
            Id = Guid.Parse("6955c5b0-dadf-41bf-b616-28cf1dea7129"),
            Name = "Software Engineer",
            CreatedAt = createdAt,
            LastTouchedBy = systemTouchedBy
        }, new Designation
        {
            Id = Guid.Parse("dfc436f4-d875-42fc-bb43-569d82dda847"),
            Name = "Senior Software Engineer",
            CreatedAt = createdAt,
            LastTouchedBy = systemTouchedBy
        }, new Designation
        {
            Id = Guid.Parse("6db98ad2-61e3-45f9-93ea-fe8af7fdd44b"),
            Name = "Team Leader",
            CreatedAt = createdAt,
            LastTouchedBy = systemTouchedBy
        }, new Designation
        {
            Id = Guid.Parse("5ecc925e-f3d8-4152-8d0a-440e3bb03b17"),
            Name = "Junior Business Analyst",
            CreatedAt = createdAt,
            LastTouchedBy = systemTouchedBy
        }, new Designation
        {
            Id = Guid.Parse("7ef46b11-e30f-4311-a358-e9d95994ae67"),
            Name = "Business Analyst",
            CreatedAt = createdAt,
            LastTouchedBy = systemTouchedBy
        }, new Designation
        {
            Id = Guid.Parse("d39fe1e8-fc62-405e-8c04-5539f141dbb2"),
            Name = "Senior Business Analyst",
            CreatedAt = createdAt,
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
