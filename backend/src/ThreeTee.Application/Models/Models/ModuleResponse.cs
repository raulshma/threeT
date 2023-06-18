
namespace ThreeTee.Application.Models.Models;

public class ModuleResponse : ModulePostRequest
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? LastTouchedBy { get; set; }
    public string? ProjectName { get; set; }
}

