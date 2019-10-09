using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchAPI.Models;

namespace SearchAPI.Controllers
{
    /// <summary>
    /// People Api, execute search on people.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {

        private readonly IBus _bus;

        public PeopleController(IBus bus)
        {
            this._bus = bus;
        }


        /// <summary>
        /// The People Search API accept request to get information about people.
        /// It queries multiple data provider to assemble information about a person.
        /// When a request a sent an investigation order is posted to the message broker
        /// </summary>
        /// <returns></returns>
        /// <response code="202">Search Accepted</response>
        [HttpPost]
        [Route("search")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PeopleSearchResponse), StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Search()
        {
            var investigatePerson = InvestigatePerson.Create();

            await this._bus.Send<InvestigatePerson>(investigatePerson);

            return await Task.FromResult(Accepted(PeopleSearchResponse.Create(investigatePerson.OrderId)));
        }


    }
}