using Microsoft.AspNetCore.Mvc;
using ThreeTee.Application.Cqrs.Departments.Commands.CreateDepartment;
using ThreeTee.Application.Cqrs.Departments.Commands.DeleteDepartment;
using ThreeTee.Application.Cqrs.Departments.Commands.UpdateDepartment;
using ThreeTee.Application.Cqrs.Departments.Queries;
using ThreeTee.Application.Models.Departments;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ApiControllerBase
    {
        // GET: api/<DepartmentController>
        [HttpGet]
        [Produces(typeof(List<DepartmentResponse>))]
        public async Task<IResult> Get([FromQuery]GetDepartmentsWithPaginationQuery query)
        {
            var items = await Mediator.Send(query);
            if (items != null) { return TypedResults.Ok(items); }
            return TypedResults.NotFound();
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        [Produces(typeof(List<DepartmentResponse>))]
        public async Task<IResult> Get([FromQuery]GetDepartmentsByIdQuery query)
        {
            var item = await Mediator.Send(query);
            if(item != null) { return TypedResults.Ok(item); }
            return TypedResults.NotFound();
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] CreateDepartmentCommand query)
        {
            var ret = await Mediator.Send(query);
            if (ret == null) { return TypedResults.BadRequest(); }
            return TypedResults.Ok(ret);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut]
        public async Task<IResult> Put([FromBody] UpdateDepartmentCommand query)
        {
            var ret = await Mediator.Send(query);
            if (ret == null) return TypedResults.BadRequest();
            return TypedResults.Ok(ret);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]

        public async Task<IResult> Delete(DeleteDepartmentCommand query)
        {
            var ret = await Mediator.Send(query);
            if(ret!= Guid.Empty)
                return TypedResults.BadRequest();
            return TypedResults.NoContent();
        }
    }
}
