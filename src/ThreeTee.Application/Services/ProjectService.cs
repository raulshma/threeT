using System.Collections.Generic;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Mappers;
using ThreeTee.Application.Models.Projects;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Services;
public class ProjectService : IProjectService
{
    private readonly IGenericRepository<Project> _repository;
    public ProjectService(IGenericRepository<Project> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProjectResponse>> GetAsync(Guid? id)
    {
        IEnumerable<Project>? items;
        if (id == null || id == Guid.Empty)
            items = await _repository.GetAsync();
        else
            items = await _repository.GetAsync(e => e.Id == id);
        var mapper = new ProjectMapper();
        return mapper.ProjectToProjectResponse(items);
    }

    public async Task<Project> InsertAsync(ProjectPostRequest request)
    {
        var mapper = new ProjectMapper();
        var result = await _repository.InsertAsync(mapper.ProjectPostRequestToProject(request));
        await _repository.SaveChangesAsync();
        return result;
    }
}

