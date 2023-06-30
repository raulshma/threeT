using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThreeTee.Application.Cqrs.Clients.Commands.CreateClient;
using ThreeTee.Application.Cqrs.Clients.Commands.DeleteClient;
using ThreeTee.Application.Cqrs.Clients.Commands.UpdateClient;
using ThreeTee.Application.Cqrs.Clients.Queries;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Models.Clients;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClientController : ApiControllerBase
    {
        
        // GET: api/<ClientController>
        [HttpGet]
        [Produces(typeof(List<ClientResponse>))]
        public async Task<IResult> Get([FromQuery] GetClientsWithPaginationQuery query)
        {
            var items = await Mediator.Send(query);
            if (items == null)
                return TypedResults.NotFound();

            return TypedResults.Ok(items);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        [Produces(typeof(ClientResponse))]
        public async Task<IResult> Get([FromQuery] GetClientByIdQuery query)
        {
            var item = await Mediator.Send(query);
            if (item != null)
                return TypedResults.Ok(item);

            return TypedResults.NotFound();
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<IResult> Post([FromQuery] CreateClientCommand query)
        {
            var ret = await Mediator.Send(query);
            if (ret == Guid.Empty) return TypedResults.BadRequest();
            return TypedResults.CreatedAtRoute(ret);
        }
        // PUT api/<ClientController>
        [HttpPut]
        public async Task<IResult> Put(UpdateClientCommand query)
        {
            var item = await Mediator.Send(query);
            return TypedResults.Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IResult> Delete(DeleteClientCommand query)
        {
            var item = await Mediator.Send(query);
            if (!item)
                return TypedResults.BadRequest();
            return TypedResults.NoContent();
        }
    }
}
