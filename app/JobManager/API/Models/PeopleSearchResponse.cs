using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JobManager.API.Models
{
    public class PeopleSearchResponse
    {
        /// <summary>
        /// The Unique Identifier of the request.
        /// </summary>
        [Required]
        [Description("The Unique Identifier of the request")]
        public Guid SearchRequestId { get; }
    }
}
