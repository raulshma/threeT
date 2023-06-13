using Riok.Mapperly.Abstractions;
using ThreeTee.Application.Models.Projects;
using ThreeTee.Application.Models.ProjectUser;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Mappers;

[Mapper]
public partial class ProjectUserMapper
{
    public partial ProjectUser ToEntity(ProjectUserUpsertRequest request);
    public partial ProjectUserResponse ToDto(ProjectPutRequest request);
    public partial ProjectUser ToModel(ProjectUserUpsertRequest request);
    public partial ProjectUserResponse ToDto(ProjectUser project);
    public partial IEnumerable<ProjectUserResponse> ToDto(IEnumerable<ProjectUser> project);
}

