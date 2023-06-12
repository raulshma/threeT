using Riok.Mapperly.Abstractions;
using ThreeTee.Application.Models.Clients;
using ThreeTee.Application.Models.Statuses;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Mappers;

[Mapper]
public partial class StatusMapper
{
    public partial Status ToEntity(StatusPostRequest request);
    public partial IEnumerable<StatusResponse> ToResponse(IEnumerable<Status> request);
    public partial StatusResponse ToResponse(Status request);
    public partial StatusResponse ToResponse(StatusPostRequest request);
}

