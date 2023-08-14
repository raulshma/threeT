using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThreeTee.Application.Cqrs.Modules.Commands.CreateModule;
using ThreeTee.Application.Cqrs.Modules.Commands.DeleteModule;
using ThreeTee.Application.Cqrs.Modules.Commands.UpdateModule;
using ThreeTee.Application.Cqrs.Modules.Queries;
using ThreeTee.Application.Models.Modules;

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ModuleController : ApiControllerBase
    {
        // GET: api/<ClientController>
        [HttpGet]
        [Produces(typeof(List<ModuleResponse>))]
        public async Task<IResult> Get([FromQuery] GetModuleWithPagination query)
        {
            var items = await Mediator.Send(query);
            if (items == null)
                return TypedResults.NotFound();

            return TypedResults.Ok(items);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        [Produces(typeof(ModuleResponse))]
        public async Task<IResult> Get([FromQuery] GetModuleByIdQuery query)
        {
            var item = await Mediator.Send(query);
            if (item != null)
                return TypedResults.Ok(item);

            return TypedResults.NotFound();
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<IResult> Post([FromQuery] CreateModuleCommand query)
        {
            var ret = await Mediator.Send(query);
            if(ret!=null)
            return TypedResults.CreatedAtRoute(ret);
            else
                return TypedResults.BadRequest();
        }
        // PUT api/<ClientController>
        [HttpPut]
        public async Task<IResult> Put(UpdateModuleCommand query)
        {
            var item = await Mediator.Send(query);
            return TypedResults.Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(DeleteModuleCommand query)
        {
            var item = await Mediator.Send(query);
            if (item==Guid.Empty)
                return TypedResults.BadRequest();
            return TypedResults.NoContent();
        }
    }
}
