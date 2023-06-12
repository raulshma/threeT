

namespace ThreeTee.Application.Models.Designations;

public class DesignationResponse : DesignationPostRequest
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? LastTouchedBy { get; set; }
}

