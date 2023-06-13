using ThreeTee.Application.Models.Clients;
using ThreeTee.Application.Models.ProjectUser;

namespace ThreeTee.Application.Interfaces;
public interface IProjectUserService
{
    Task<IEnumerable<ProjectUserResponse>> GetAsync();
    //Task<IEnumerable<ProjectUserResponse>> GetAsync(Guid? id);
    Task<ProjectUserResponse> InsertAsync(ProjectUserUpsertRequest request);
    Task<ProjectUserResponse> UpdateAsync(ProjectUserUpsertRequest request);
    Task DeleteAsync(Guid id);
}

