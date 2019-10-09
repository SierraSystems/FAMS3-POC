using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchAPI.Models;

namespace SearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        /// <summary>
        /// The People Search API accept request to get information about people.
        /// It queries multiple data provider to assemble information about a person.
        /// </summary>
        /// <returns></returns>
        /// <response code="202">Search Accepted</response>
        [HttpPost]
        [Route("search")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PeopleSearchResponse), StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Search()
        {
            return await Task.FromResult(Accepted(PeopleSearchResponse.Create()));
        }


    }
}