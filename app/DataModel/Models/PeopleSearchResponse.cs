using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataModel.Models
{
    public class PeopleSearchResponse
    {
        /// <summary>
        /// The Unique Identifier of the request.
        /// </summary>
        [Required]
        [Description("The Unique Identifier of the request")]
        public Guid SearchRequestId { get; }

        private PeopleSearchResponse(Guid searchRequestId)
        {
            this.SearchRequestId = searchRequestId;
        }

        public static PeopleSearchResponse Create(Guid requestId)
        {
            return new PeopleSearchResponse(requestId);
        }
    }
}
