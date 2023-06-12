using ThreeTee.Application.Models.Clients;
using ThreeTee.Application.Models.Statuses;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Interfaces;

    public interface IStatusService
{
    Task<IEnumerable<StatusResponse>> GetAsync();
    //Task<IEnumerable<StatusResponse>> GetAsync(Guid? id);
    Task<StatusResponse?> GetByIdAsync(Guid? id);
    Task<StatusResponse> InsertAsync(StatusPostRequest request);
}

