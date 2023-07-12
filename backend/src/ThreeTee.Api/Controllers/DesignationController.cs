using Microsoft.AspNetCore.Mvc;
using ThreeTee.Application.Cqrs.Designations.Commands.CreateDesignation;
using ThreeTee.Application.Cqrs.Designations.Commands.DeleteDesignation;
using ThreeTee.Application.Cqrs.Designations.Commands.UpdateDesignation;
using ThreeTee.Application.Cqrs.Designations.Queries;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Models.Designations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ApiControllerBase
    {

        // GET: api/<DesignationController>
        [HttpGet]
        public async Task<IResult> Get([FromQuery]GetDesignationWithPaginationQuery query)
        {
            var items = await Mediator.Send(query);
            return TypedResults.Ok(items);
        }

        // GET api/<DesignationController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get([FromQuery]GetDesignationsByIdQuery query)
        {
            var item = await Mediator.Send(query);
            return TypedResults.Ok(item);
        }

        // POST api/<DesignationController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] CreateDesignationCommand query)
        {
            var ret = await Mediator.Send(query);
            if(ret != null) { return TypedResults.Ok(ret); }
            return null;
        }

        // PUT api/<DesignationController>/5
        [HttpPut]
        public async Task<IResult> Put([FromBody] UpdateDesignationCommand query)
        {
            var ret = await Mediator.Send(query);
            if(ret != null) { return TypedResults.Ok(ret); }
            return null;
        }

        // DELETE api/<DesignationController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(DeleteDesignationCommand query)
        {
            var res = await Mediator.Send(query);
            return TypedResults.NoContent();
        }
    }
}
