using System;
using Newtonsoft.Json;

namespace SearchApi.Core.Contracts.PersonSearch
{

    /// <summary>
    /// The searchRequested represents an event resulting of a system requesting a search on a person
    /// </summary>
    public class SearchRequested
    {

        [JsonConstructor]
        public SearchRequested()
        {
            this.CorrelationId = Guid.NewGuid();
        }

        public Guid CorrelationId { get; }


        public static SearchRequested Create()
        {
            return new SearchRequested();
        } 


    }

}