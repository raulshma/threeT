using ThreeTee.Application.Models.Clients;
using ThreeTee.Application.Models.Departments;

namespace ThreeTee.Application.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentResponse>> GetAsync();
    Task<DepartmentResponse?> GetByIdAsync(Guid? id);
    Task<DepartmentResponse> InsertAsync(DepartmentPostRequest request);
    Task<DepartmentResponse> UpdateAsync(DepartmentPutRequest request);
    Task DeleteAsync(Guid id);
}

