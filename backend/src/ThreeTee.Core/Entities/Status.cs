using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeTee.Core.Entities;

public class Status : BaseEntityWithKey<Guid>
{
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime DateFor { get; set; }
    public bool Leave { get; set; }
    [Required]
    public bool? ClientUpdated { get; set; }
    [Required]
    public int Minutes { get; set; }
    public Guid BillingTypeId { get; set; }
    public virtual BillingType BillingType { get; set; }
    public List<Guid> SendToUserIds { get; set; }
    public List<Guid> SendCcToUserIds { get; set; }
    public Guid ProjectId { get; set; }
    public virtual Project Project { get; set; }
    public Guid ModuleId { get; set; }
    public virtual Module Module { get; set; }
    public Guid? ProfileId { get; set; }
    public virtual Profile Profile { get; set; }
}

