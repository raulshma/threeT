using ThreeTee.Application.Models.Modules;

namespace ThreeTee.Application.Models.Modules;

public class ModuleResponse : ModulePostRequest
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? LastTouchedBy { get; set; }
    public string? ProjectName { get; set; }
}
