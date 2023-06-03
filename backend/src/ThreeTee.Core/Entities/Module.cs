using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Core.Entities;
public class Module : BaseEntityWithKey<Guid>
{
    [Required]
    public string Name { get; set; }
    [Required]
    public Guid ProjectId { get; set; }
    public virtual Project Project { get; set; }

}
