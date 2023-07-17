using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using ThreeTee.Application.Cqrs.ProjectUsers.Commands.CreateProjectUser;
using ThreeTee.Application.Cqrs.ProjectUsers.Commands.DeleteProjectUser;
using ThreeTee.Application.Cqrs.ProjectUsers.Commands.UpdateProjectUser;
using ThreeTee.Application.Cqrs.ProjectUsers.Queries;
using ThreeTee.Application.Models.ProjectUser;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectUserController : ApiControllerBase
    {
        // GET: api/<ProjectUserController>
        [HttpGet]
        [Produces(typeof(List<ProjectUserResponse>))]
        public async Task<IResult> Get([FromQuery] GetProjectUsersWithPaginationQuery query)
        {
            var items = await Mediator.Send(query);
            if (items == null)
                return TypedResults.NotFound();
            return TypedResults.Ok(items);
        }

        //GET PROJECT USER LIST api/<ProjectUserController>
        [HttpPost("{UserId}")]
        [Produces(typeof(List<ProjectUserResponse>))]
        public async Task<IResult> Get([FromQuery] GetProjectUsersWithUserIdPaginationQuery query)
        {
            var items = await Mediator.Send(query);
            if (items != null)
                return TypedResults.NotFound();
            return TypedResults.Ok(items);
        }

        // POST api/<ProjectUserController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] CreateProjectUserCommand query)
        {
            var items = await Mediator.Send(query);
            if (items != Guid.Empty)
            { return TypedResults.Created(items.ToString()); }
            return TypedResults.BadRequest();
        }

        // PUT api/<ProjectUserController>
        [HttpPut]
        public async Task<IResult> Put(UpdateProjectUserCommand query)
        {
            var item = await Mediator.Send(query);
            return TypedResults.Ok(item);
        }

        // DELETE api/<ProjectUserController>
        [HttpDelete("{UserId}")]
        public async Task<IResult> Delete(DeleteProjectUserCommand query)
        {
            var item = await Mediator.Send(query);
            if (!item)
                return TypedResults.BadRequest();
            return TypedResults.NoContent();
        }
    }
}
