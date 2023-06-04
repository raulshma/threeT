using System.ComponentModel.DataAnnotations;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Models.Clients;

public class ClientPostRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime BoardedOn { get; set; }
    public Guid BoardedById { get; set; }
    public string? Country { get; set; }
    [Required]
    public bool IsActive { get; set; }
    public Guid BillingTypeId { get; set; }
}
