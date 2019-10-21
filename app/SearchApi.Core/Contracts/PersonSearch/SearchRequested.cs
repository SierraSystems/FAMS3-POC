using System;
using Newtonsoft.Json;
using SearchApi.Core.Models;

namespace SearchApi.Core.Contracts.PersonSearch
{

    /// <summary>
    /// The searchRequested represents an event resulting of a system requesting a search on a person
    /// </summary>
    public class SearchRequested
    {

        [JsonConstructor]
        public SearchRequested(PeopleSearchRequest peopleSearchRequest)
        {
            this.CorrelationId = Guid.NewGuid();
            this.PeopleSearchRequest = peopleSearchRequest;
        }

        public Guid CorrelationId { get; }
        public PeopleSearchRequest PeopleSearchRequest { get; }


        public static SearchRequested Create(PeopleSearchRequest peopleSearchRequest)
        {
            return new SearchRequested(peopleSearchRequest);
        } 


    }

}