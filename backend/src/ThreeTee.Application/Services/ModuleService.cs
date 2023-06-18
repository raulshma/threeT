using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Mappers;
using ThreeTee.Application.Models.Models;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Services;
internal class ModuleService : IModuleService
{
    public readonly IGenericRepository<Module> _repository;
    public readonly IProjectService _projectService;
    public readonly ModuleMapper _mapper;
    public ModuleService(IGenericRepository<Module> repository, IProjectService projectService)
    {
        _mapper = new ModuleMapper();
        _repository = repository;
        _projectService = projectService;
    }
    public async Task DeleteAsync(Guid id)
    {
        _repository.Delete(id);
        await _repository.SaveChangesAsync();
    }

    public async Task<IEnumerable<ModuleResponse>> GetAsync()
    {

        IEnumerable<Module> items = await _repository.GetAsync();
        if (items.Any())
        {
            foreach (var item in items)
            {
                var projectResult = _projectService.GetAsync(item.ProjectId)?.Result;
                if (projectResult != null)
                    item.Project.Name = projectResult.FirstOrDefault()?.Name;

                return _mapper.ToDto(items);
            }
        }
        return Enumerable.Empty<ModuleResponse>();
    }

    public async Task<ModuleResponse?> GetByIdAsync(Guid? id)
    {
        var item = await _repository.GetByIDAsync(id);
        if (item != null)
        {
            var projectVal = _projectService.GetAsync(item.ProjectId).Result;
            if (projectVal != null)
            {
                item.Project.Name = projectVal.FirstOrDefault()?.Name;
                return _mapper.ToDto(item);
            }
        }
        return null;
    }

    public async Task<ModuleResponse> InsertAsync(ModulePostRequest request)
    {
        var ret = await _repository.InsertAsync(_mapper.ToEntity(request));
        if (ret != null)
        {
            await _repository.SaveChangesAsync();
            var projectVal = _projectService.GetAsync(ret.ProjectId).Result;
            if (projectVal != null) { ret.Project.Name = projectVal.FirstOrDefault()?.Name; }
            return _mapper.ToDto(ret);
        }
        return null;
    }

    public async Task<ModuleResponse> UpdateAsync(ModulePutRequest request)
    {
        var result = await _repository.UpdateAsync(_mapper.ToEntity(request));
        if (result != null)
        {
            await _repository.SaveChangesAsync();
            var projectVal = _projectService.GetAsync(result.ProjectId).Result;
            if (projectVal != null) { result.Project.Name = projectVal.FirstOrDefault()?.Name; }
            return _mapper.ToDto(result);
        }
        return null;
    }


}

