using Microsoft.AspNetCore.Mvc;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Models.Models;

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        public readonly IModuleService _moduleService;
        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        // GET: api/<ModuleController>
        [HttpGet]
        public async Task<IResult> Get()
        {
            var items = await _moduleService.GetAsync();
            
            return TypedResults.Ok(items);
        }

        // GET api/<ModuleController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get(Guid id)
        {
            var item = await _moduleService.GetByIdAsync(id);
            if (item == null) return TypedResults.NotFound();
            return TypedResults.Ok(item);
        }

        // POST api/<ModuleController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] ModulePostRequest value)
        {
            if (value?.Name != "")
            {
                var ret = await _moduleService.InsertAsync(value);
                if (ret != null) { return TypedResults.Ok(ret); }
                return TypedResults.BadRequest();
            }
            else
                return TypedResults.BadRequest("Invalid module name");
        }

        // PUT api/<ModuleController>/5
        [HttpPut]
        public async Task<IResult> Put([FromBody] ModulePutRequest value)
        {
            if (value?.Name != "")
            {
                var ret = await _moduleService.UpdateAsync(value);
                if (ret != null) { return TypedResults.Ok(ret); }
                return TypedResults.NotFound("Module not found");
            }
            else
                return TypedResults.BadRequest("Invalid module name");
        }

        // DELETE api/<ModuleController>/5
        [HttpDelete("{id}")]
        public async Task<IResult> Delete(Guid id)
        {
            _moduleService.DeleteAsync(id);
            return TypedResults.NoContent();
        }
    }
}
