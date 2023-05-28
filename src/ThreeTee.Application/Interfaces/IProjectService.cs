using ThreeTee.Application.Models.Projects;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Interfaces;
public interface IProjectService
{
    Task<IEnumerable<ProjectResponse>> GetAsync(Guid? id);
    Task<Project> InsertAsync(ProjectPostRequest request);
}

