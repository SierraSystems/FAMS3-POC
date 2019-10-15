using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchApi.Core.Contracts;
using SearchApi.Core.Contracts.PersonSearch;
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

        private readonly IBusControl _busControl;

        public PeopleController(IBusControl busControl)
        {
            this._busControl = busControl;
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
            var searchRequested = SearchRequested.Create();

            await this._busControl.Publish(searchRequested);

            return Accepted(PeopleSearchResponse.Create(searchRequested.CorrelationId));
        }


    }
}