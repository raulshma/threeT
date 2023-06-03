using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Core.Entities;
public class BillingType : BaseEntityWithKey<Guid>
{
    [Required]
    public string Name { get; set; }
}

