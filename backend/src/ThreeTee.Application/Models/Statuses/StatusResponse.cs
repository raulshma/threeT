
namespace ThreeTee.Application.Models.Statuses;

public class StatusResponse : StatusPostRequest
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? LastTouchedBy { get; set; }
}

