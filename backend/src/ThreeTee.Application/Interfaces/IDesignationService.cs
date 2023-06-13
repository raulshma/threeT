using ThreeTee.Application.Models.Designations;

namespace ThreeTee.Application.Interfaces;

public interface IDesignationService
{
    Task<IEnumerable<DesignationResponse>> GetAsync();
    Task<DesignationResponse?> GetByIdAsync(Guid? id);
    Task<DesignationResponse> InsertAsync(DesignationPostRequest request);
    Task<DesignationResponse> UpdateAsync(DesignationPutRequest request);
    Task DeleteAsync(Guid id);
}

