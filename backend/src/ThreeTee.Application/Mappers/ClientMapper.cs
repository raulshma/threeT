using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeTee.Application.Models.Clients;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Mappers;

[Mapper]
public partial class ClientMapper
{
    public partial Client ToEntity(ClientPostRequest request);
    public partial IEnumerable<ClientResponse> ToResponse(IEnumerable<Client> request);
    public partial ClientResponse ToResponse(Client request);
    public partial ClientResponse ToResponse(ClientPostRequest request);
}
