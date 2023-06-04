using Microsoft.AspNetCore.Mvc;
using ThreeTee.Application.Interfaces;
using ThreeTee.Application.Models.Clients;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        // GET: api/<ClientController>
        [HttpGet]
        [Produces(typeof(List<ClientResponse>))]
        public async Task<IResult> Get()
        {
            var items = await _clientService.GetAsync();
            return TypedResults.Ok(items);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        [Produces(typeof(ClientResponse))]
        public async Task<IResult> Get(Guid id)
        {
            var item = await _clientService.GetByIdAsync(id);
            return TypedResults.Ok(item);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<IResult> Post([FromBody] ClientPostRequest value)
        {
            var ret = await _clientService.InsertAsync(value);
            if (ret == null) return TypedResults.BadRequest();
            return TypedResults.Created(ret.Id.ToString());
        }

        //// PUT api/<ClientController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ClientController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
