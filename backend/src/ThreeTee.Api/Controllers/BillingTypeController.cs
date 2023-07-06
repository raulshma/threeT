using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThreeTee.Application.Cqrs.Clients.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BillingTypeController : ApiControllerBase
    {

        // GET: api/<BillingTypeController>
        [HttpGet]
        public async Task<IResult> GetAsync([FromQuery] GetClientsWithPaginationQuery query)
        {
            var items = await Mediator.Send(query);
            if (items == null)
                return TypedResults.NotFound();

            return TypedResults.Ok(items);
        }

        // GET api/<BillingTypeController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get([FromQuery] GetClientByIdQuery query)
        {
            var item = await Mediator.Send(query);
            if (item != null)
                return TypedResults.Ok(item);

            return TypedResults.NotFound();
        }
    }
}
