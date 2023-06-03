using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Core.Entities;

public class Department : BaseEntityWithKey<Guid>
{
    [Required]
    public string Name { get; set; }
    public string Code { get; set; }
    public virtual ICollection<DepartmentManager> DepartmentManagers { get; set; }
}

