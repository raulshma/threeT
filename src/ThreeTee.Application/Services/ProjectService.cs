using System.Collections.Generic;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Mappers;
using ThreeTee.Application.Models.Projects;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Services;
public class ProjectService : IProjectService
{
    private readonly IUnitOfWork _unitOfWork;
    public ProjectService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ProjectResponse>> GetAsync(Guid? id)
    {
        IEnumerable<Project>? items;
        if (id == null || id == Guid.Empty)
            items = await _unitOfWork.ProjectRepository.GetAsync();
        else
            items = await _unitOfWork.ProjectRepository.GetAsync(e => e.Id == id);
        var mapper = new ProjectMapper();
        return mapper.ProjectToProjectResponse(items);
    }

    public async Task<Project> InsertAsync(ProjectPostRequest request)
    {
        var mapper = new ProjectMapper();
        var result = await _unitOfWork.ProjectRepository.InsertAsync(mapper.ProjectPostRequestToProject(request));
        await _unitOfWork.SaveAsync();
        return result;
    }
}

