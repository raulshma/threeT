using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Core.Entities;
public class Profile : BaseEntityWithKey<Guid>
{
    [Required]
    public string Name { get; set; }
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; }
}

