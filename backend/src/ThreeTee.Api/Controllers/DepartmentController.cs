using Microsoft.AspNetCore.Mvc;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Models.Departments;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
                _departmentService = departmentService;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        [Produces(typeof(List<DepartmentResponse>))]
        public async Task<IResult> Get()
        {
            var items = await _departmentService.GetAsync();
            return TypedResults.Ok(items);
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        [Produces(typeof(List<DepartmentResponse>))]
        public async Task<IResult> Get(Guid id)
        {
            var item = await _departmentService.GetByIdAsync(id);
            return TypedResults.Ok(item);
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] DepartmentPostRequest value)
        {
            var ret = await _departmentService.InsertAsync(value);
            if(ret==null) { return null; }
            return TypedResults.Ok(ret);
        }

        // PUT api/<DepartmentController>/5
        [HttpPut]
        public async Task<IResult> Put([FromBody] DepartmentPutRequest value)
        {
            var ret = await _departmentService.UpdateAsync(value);
            if (ret == null) return null;
            return TypedResults.Ok(ret);
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]

        public async Task<IResult> Delete(Guid id)
        {
            await _departmentService.DeleteAsync(id);
            return TypedResults.NoContent();
        }
    }
}
