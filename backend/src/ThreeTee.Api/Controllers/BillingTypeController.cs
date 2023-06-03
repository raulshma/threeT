using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ThreeTee.Application.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingTypeController : ControllerBase
    {
        private readonly IBillingTypeService _billingTypeService;

        public BillingTypeController(IBillingTypeService billingTypeService)
        {
            this._billingTypeService = billingTypeService;
        }
        // GET: api/<BillingTypeController>
        [HttpGet]
        public async Task<IResult> GetAsync()
        {
            var items = await _billingTypeService.GetAsync(null);
            return TypedResults.Ok(items);
        }

        // GET api/<BillingTypeController>/5
        [HttpGet("{id}")]
        public async Task<IResult> Get([Required] Guid id)
        {
            var items = await _billingTypeService.GetAsync(id);
            return TypedResults.Ok(items);
        }
    }
}
