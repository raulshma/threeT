using System.Collections.Generic;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Mappers;
using ThreeTee.Application.Models.Projects;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Services;
public class ProjectService : IProjectService
{
    private readonly IGenericRepository<Project> _repository;
    private readonly ProjectMapper _mapper;
    public ProjectService(IGenericRepository<Project> repository)
    {
        _repository = repository;
        _mapper = new ProjectMapper();
    }

    public async Task<IEnumerable<ProjectResponse>> GetAsync(Guid? id)
    {
        IEnumerable<Project>? items;
        if (id == null || id == Guid.Empty)
            items = await _repository.GetAsync();
        else
            items = await _repository.GetAsync(e => e.Id == id);
        return _mapper.ToDto(items);
    }

    public async Task<ProjectResponse> InsertAsync(ProjectPostRequest request)
    {
        var result = await _repository.InsertAsync(_mapper.ToModel(request));
        await _repository.SaveChangesAsync();
        return _mapper.ToDto(result);
    }

    public async Task<ProjectResponse> UpdateAsync(ProjectPutRequest request)
    {
        var model = _mapper.ToModel(request);
        _repository.Update(model);
        await _repository.SaveChangesAsync();
        return _mapper.ToDto(model);
    }

    public async Task DeleteAsync(Guid id)
    {
        _repository.Delete(id);
        await _repository.SaveChangesAsync();
    }
}

