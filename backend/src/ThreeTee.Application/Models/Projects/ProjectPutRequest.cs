using System.ComponentModel.DataAnnotations;

namespace ThreeTee.Application.Models.Projects;

public class ProjectPutRequest
{
    [Required]
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public double? BillingPrice { get; set; }
    public required Guid ClientId { get; set; }

}
