
using ThreeTee.Application.Models.Modules;

namespace ThreeTee.Application.Interfaces;
public interface IModuleService
{
    Task<IEnumerable<ModuleResponse>> GetAsync();
    Task<ModuleResponse?> GetByIdAsync(Guid? id);
    Task<ModuleResponse> InsertAsync(ModulePostRequest request);
    Task<ModuleResponse> UpdateAsync(ModulePutRequest request);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<ModuleResponse>> GetAllByProjectID(Guid projectId);
    Task DeleteByProjectId(Guid projectId);
}
