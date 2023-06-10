using Riok.Mapperly.Abstractions;
using ThreeTee.Application.Models.Clients;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Mappers;

[Mapper]
public partial class ClientMapper
{
    public partial Client ToEntity(ClientPostRequest request);
    public partial Client ToEntity(ClientPutRequest request);
    public partial IEnumerable<ClientResponse> ToDto(IEnumerable<Client> request);
    public partial ClientResponse ToDto(Client request);
    public partial ClientResponse ToDto(ClientPostRequest request);
}
