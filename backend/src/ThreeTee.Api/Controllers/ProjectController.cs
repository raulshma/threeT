using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThreeTee.Application.Cqrs.Projects.Commands.CreateProject;
using ThreeTee.Application.Cqrs.Projects.Commands.DeleteProject;
using ThreeTee.Application.Cqrs.Projects.Commands.UpdateProject;
using ThreeTee.Application.Cqrs.Projects.Queries;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Models.Projects;
using ThreeTee.Application.Models.ProjectUser;

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : ApiControllerBase
    {

        // GET: api/<ProjectController>
        [HttpGet]
        [Produces(typeof(List<ProjectResponse>))]
        public async Task<IResult> GetAsync([FromQuery] GetProjectsWithPaginationQuery query)
        {
            var items = await Mediator.Send(query);
            if (items == null)
                return TypedResults.NotFound();

            return TypedResults.Ok(items);
        }

        //GETByID : api/<ProjectController>
        [HttpGet("{id}")]
        public async Task<IResult> GetAsync([FromQuery] GetProjectByIdQuery query)
        {
            var item = await Mediator.Send(query);
            if (item != null)
                return TypedResults.Ok(item);

            return TypedResults.NotFound();
        }

        // POST api/<ProjectController>
        [HttpPost]
        public async Task<IResult> PostAsync(CreateProjectCommand query)
        {
            var item = await Mediator.Send(query);
            return TypedResults.CreatedAtRoute(item);
        }

        // PUT api/<ProjectController>
        [HttpPut]
        public async Task<IResult> PutAsync(UpdateProjectCommand query)
        {
            var item = await Mediator.Send(query);
            return TypedResults.Ok(item);
        }

        // DELETE api/<ProjectController>
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteAsync(DeleteProjectCommand query)
        {
            var item = await Mediator.Send(query);
            if (!item)
                return TypedResults.BadRequest();
            return TypedResults.NoContent();
        }
    }
}
