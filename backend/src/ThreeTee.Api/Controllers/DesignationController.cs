using Microsoft.AspNetCore.Mvc;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Models.Designations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationService _designationService;
        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;
        }

        // GET: api/<DesignationController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            var items = await _designationService.GetAsync();
            return TypedResults.Ok(items);
        }

        // GET api/<DesignationController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(Guid id)
        {
            var item = await _designationService.GetByIdAsync(id);
            return TypedResults.Ok(item);
        }

        // POST api/<DesignationController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] DesignationPostRequest value)
        {
            var ret = await _designationService.InsertAsync(value);
            if(ret != null) { return TypedResults.Ok(ret); }
            return null;
        }

        // PUT api/<DesignationController>/5
        [HttpPut]
        public async Task<IResult> Put([FromBody] DesignationPutRequest value)
        {
            var ret = await _designationService.UpdateAsync(value);
            if(ret != null) { return TypedResults.Ok(ret); }
            return null;
        }

        // DELETE api/<DesignationController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(Guid id)
        {
            _designationService.DeleteAsync(id);
            return TypedResults.NoContent();
        }
    }
}
