namespace ThreeTee.Application.Models.ProjectUser;

public class ProjectUserUpsertRequest
{
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
}

