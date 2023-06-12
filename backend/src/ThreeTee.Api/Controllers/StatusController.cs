using Microsoft.AspNetCore.Mvc;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Models.Statuses;

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        // GET: api/<StatusController>
        [HttpGet]
        [Produces(typeof(List<StatusResponse>))]
        public async Task<IResult> Get()
        {
            var items = await _statusService.GetAsync();
            return TypedResults.Ok(items);
        }

        //GET: api/<StatusController>
        [HttpGet("{id}")]
        public async Task<IResult> GetAsync(Guid? id)
        {
            var items = await _statusService.GetByIdAsync(id);
            return TypedResults.Ok(items);
        }

        // POST: api/<StatusController>
        [HttpPost]
        public async Task<IResult> PostAsync(StatusPostRequest request)
        {
            var item = await _statusService.InsertAsync(request);
            return TypedResults.CreatedAtRoute(item);
        }
    }
}
