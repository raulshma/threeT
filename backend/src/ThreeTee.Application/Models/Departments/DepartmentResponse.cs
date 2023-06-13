
namespace ThreeTee.Application.Models.Departments;

public class DepartmentResponse : DepartmentPostRequest
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? LastTouchedBy { get; set; }
}

