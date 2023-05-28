using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Core.Entities;
public class ApplicationUser : IdentityUser<Guid>
{
    public int? Experience { get; set; }
    public DateTime? JoiningDate { get; set; }
    public DateTime? RelievingDate { get; set; }
    public Guid? DesignationId { get; set; }
    public virtual Designation Designation { get; set; }
    public Guid? DepartmentId { get; set; }
    public virtual Department Department { get; set; }
}
