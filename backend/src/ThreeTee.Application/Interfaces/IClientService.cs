using ThreeTee.Application.Models.Clients;

namespace ThreeTee.Application.Interfaces;

public interface IClientService
{
    Task<IEnumerable<ClientResponse>> GetAsync();
    Task<ClientResponse?> GetByIdAsync(Guid? id);
    Task<ClientResponse> InsertAsync(ClientPostRequest request); 
    Task<ClientResponse> UpdateAsync(ClientPutRequest request);
    Task DeleteAsync(Guid id);
}