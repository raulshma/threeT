using Riok.Mapperly.Abstractions;
using ThreeTee.Application.Models.Projects;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Mappers;

[Mapper]
public partial class ProjectMapper
{
    public partial Project ProjectPostRequestToProject(ProjectPostRequest request);
    public partial ProjectResponse ProjectToProjectResponse(Project project);
    public partial IEnumerable<ProjectResponse> ProjectToProjectResponse(IEnumerable<Project> project);
}

