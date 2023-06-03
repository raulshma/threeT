using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Core.Entities;
public class UserDepartment : BaseEntity
{
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; }
    public Guid DeparmentId { get; set; }
    public Department Department { get; set; }
}

