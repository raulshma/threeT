using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Models.Projects;
using ThreeTee.Core.Entities;

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public async Task<IResult> GetAsync(Guid? id)
        {
            var items = await _projectService.GetAsync(id);
            return TypedResults.Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetAsync(Guid id)
        {
            var item = await _projectService.GetAsync(id);
            return TypedResults.Ok(item.FirstOrDefault());
        }

        [HttpPost]
        public async Task<IResult> PostAsync(ProjectPostRequest request)
        {
            var item = await _projectService.InsertAsync(request);
            return TypedResults.CreatedAtRoute(item);
        }
        
        [HttpPut]
        public async Task<IResult> PutAsync(ProjectPutRequest request)
        {
            var item = await _projectService.UpdateAsync(request);
            return TypedResults.Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteAsync(Guid id)
        {
            await _projectService.DeleteAsync(id);
            return TypedResults.NoContent();
        }
    }
}
