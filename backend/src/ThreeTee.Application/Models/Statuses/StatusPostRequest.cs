using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Application.Models.Statuses;

public class StatusPostRequest
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
    public List<Guid> SendToUserIds { get; set; }
    public List<Guid> SendCcToUserIds { get; set; }
    public Guid ProjectId { get; set; }
    public Guid ModuleId { get; set; }
    public Guid? ProfileId { get; set; }
}

