using Riok.Mapperly.Abstractions;
using ThreeTee.Application.Models.Modules;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Mappers;
[Mapper]
public partial class ModuleMapper
{
    public partial Module ToEntity(ModulePostRequest request);
    public partial Module ToEntity(ModulePutRequest request);
    public partial IEnumerable<ModuleResponse> ToDto(IEnumerable<Module> request);
    public partial ModuleResponse ToDto(Module request);
    public partial ModuleResponse ToDto(ModulePostRequest request);
}
