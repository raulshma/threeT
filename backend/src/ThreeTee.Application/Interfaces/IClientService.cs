using ThreeTee.Application.Models.Clients;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientResponse>> GetAsync();
    Task<ClientResponse?> GetByIdAsync(Guid? id);
    Task<ClientResponse> InsertAsync(ClientPostRequest request);
}