namespace ThreeTee.Application.Models.Projects;
public class ProjectResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public double? BillingPrice { get; set; }
    public Guid ClientId { get; set; }
}
