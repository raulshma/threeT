using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Core.Entities;
public class ProjectUser : BaseEntity
{
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; }
    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
}

