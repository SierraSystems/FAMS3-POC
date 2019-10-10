using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        private readonly ISendEndpointProvider _sendEndpointProvider;

        public PeopleController(ISendEndpointProvider sendEndpointProvider)
        {
            this._sendEndpointProvider = sendEndpointProvider;
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

            await this._sendEndpointProvider.Send(investigatePerson);

            return Accepted(PeopleSearchResponse.Create(investigatePerson.OrderId));
        }


    }
}