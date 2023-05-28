using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Core.Entities;
public class Designation : BaseEntityWithKey<Guid>
{
    [Required]
    public string Name { get; set; }
}

