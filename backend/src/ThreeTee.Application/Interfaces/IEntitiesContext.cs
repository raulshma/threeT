using Microsoft.EntityFrameworkCore;
using ThreeTee.Core.Entities;

public interface IEntitiesContext
{
    DbSet<BillingType> BillingTypes { get; set; }
    DbSet<Client> Clients { get; set; }
    DbSet<Department> Departments { get; set; }
    DbSet<Designation> Designations { get; set; }
    DbSet<Module> Modules { get; set; }
    DbSet<Profile> Profiles { get; set; }
    DbSet<Project> Projects { get; set; }
    DbSet<ProjectUser> ProjectUsers { get; set; }
    DbSet<Status> Statuses { get; set; }
    DbSet<UserDepartment> UserDepartments { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}