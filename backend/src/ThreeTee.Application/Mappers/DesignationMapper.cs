using Riok.Mapperly.Abstractions;
using ThreeTee.Application.Models.Clients;
using ThreeTee.Application.Models.Departments;
using ThreeTee.Application.Models.Designations;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Mappers;

[Mapper]
public partial class DesignationMapper
{
    public partial Designation ToEntity(DesignationPostRequest request);
    public partial Designation ToEntity(DesignationPutRequest request);
    public partial IEnumerable<DesignationResponse> ToDto(IEnumerable<Designation> request);
    public partial DesignationResponse ToDto(Designation request);
    public partial DesignationResponse ToDto(DesignationPostRequest request);
}
