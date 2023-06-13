using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Models.ProjectUser;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectUserController : ControllerBase
    {
        private readonly IProjectUserService _projectUserService;

        public ProjectUserController(IProjectUserService projectUserService)
        {
            _projectUserService  = projectUserService;
        }
        // GET: api/<ClientController>
        [HttpGet]
        [Produces(typeof(List<ProjectUserResponse>))]
        public async Task<IResult> Get()
        {
            var items = await _projectUserService.GetAsync();
            return TypedResults.Ok(items);
        }

        [HttpGet("{id}")]
        [Produces(typeof(List<ProjectUserResponse>))]
        public async Task<IResult> Get(Guid id)
        {
            var items = await _projectUserService.GetByProjectId(id);
            return TypedResults.Ok(items);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] ProjectUserUpsertRequest value)
        {

            var ret = await _projectUserService.InsertAsync(value);
            if (ret == null) return TypedResults.BadRequest();
            return TypedResults.Created(ret.ProjectId.ToString());
        }
        // PUT api/<ClientController>
        [HttpPut]
        public async Task<IResult> Put(ProjectUserUpsertRequest request)
        {
            var item = await _projectUserService.UpdateAsync(request);
            return TypedResults.Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(Guid id)
        {
            await _projectUserService.DeleteAsync(id);
            return TypedResults.NoContent();
        }

    }
}
