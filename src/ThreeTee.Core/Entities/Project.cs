using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThreeTee.Core.Entities;
public class Project : BaseEntityWithKey<Guid>
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public double? BillingPrice { get; set; }
    public Guid ClientId { get; set; }
    public virtual Client Client { get; set; }
    public virtual ICollection<Module> Modules { get; set; }
}
