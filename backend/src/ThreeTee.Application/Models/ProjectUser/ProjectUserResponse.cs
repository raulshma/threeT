﻿
namespace ThreeTee.Application.Models.ProjectUser;

public class ProjectUserResponse
{
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string? UserDesignationName { get; set; }
    public DateTime? UserJoiningDate { get; set; }
    public int? UserExperienceYears { get; set; }
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
}

