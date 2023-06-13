using Riok.Mapperly.Abstractions;
using ThreeTee.Application.Models.Clients;
using ThreeTee.Application.Models.Departments;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Mappers;

[Mapper]
public partial class DepartmentMapper
{
    public partial Department ToEntity(DepartmentPostRequest request);
    public partial Department ToEntity(DepartmentPutRequest request);
    public partial IEnumerable<DepartmentResponse> ToDto(IEnumerable<Department> request);
    public partial DepartmentResponse ToDto(Department request);
    public partial DepartmentResponse ToDto(DepartmentPostRequest request);
}