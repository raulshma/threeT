using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using ThreeTee.Infrastructure.Persistence.Npgsql.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThreeTee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        // GET: api/<ApplicationUserController>
        [HttpGet]
        public async Task<IResult> Get([FromServices] EntitiesContext context)
        {
            var users = await context.Users.ToListAsync();
            return TypedResults.Ok(users);
        }
    }
}
