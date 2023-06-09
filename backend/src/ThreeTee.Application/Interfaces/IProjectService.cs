﻿using ThreeTee.Application.Models.Projects;
using ThreeTee.Core.Entities;

namespace ThreeTee.Application.Interfaces;
public interface IProjectService
{
    Task<IEnumerable<ProjectResponse>> GetAsync(Guid? id);
    Task<ProjectResponse> InsertAsync(ProjectPostRequest request);
    Task<ProjectResponse> UpdateAsync(ProjectPutRequest request);
    Task DeleteAsync(Guid id);
}

