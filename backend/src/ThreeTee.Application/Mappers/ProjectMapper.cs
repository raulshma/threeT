using Riok.Mapperly.Abstractions;
using ThreeTee.Application.Models.Projects;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Mappers;

[Mapper]
public partial class ProjectMapper
{
    public partial Project ToModel(ProjectPostRequest request);
    public partial ProjectResponse ToDto(ProjectPutRequest request);
    public partial Project ToModel(ProjectPutRequest request);
    public partial ProjectResponse ToDto(Project project);
    public partial IEnumerable<ProjectResponse> ToDto(IEnumerable<Project> project);
}

