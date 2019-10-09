using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SearchAPI.Models
{
    /// <summary>
    /// Represents the search request acknowledgment response.
    /// </summary>
    public class PeopleSearchResponse
    {
        private PeopleSearchResponse(Guid searchRequestId)
        {
            this.SearchRequestId = searchRequestId;
        }

        /// <summary>
        /// The Unique Identifier of the request.
        /// </summary>
        [Required]
        [Description("The Unique Identifier of the request")]
        public Guid SearchRequestId { get; }

        /// <summary>
        /// Creates a new PeopleSearchResponse
        /// </summary>
        /// <returns></returns>
        public static PeopleSearchResponse Create()
        {
            return new PeopleSearchResponse(Guid.NewGuid());
        }

    }
}