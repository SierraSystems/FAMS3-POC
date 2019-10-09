using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;

namespace SearchAPI.Models
{
    /// <summary>
    /// Represent an order to investigate on a person
    /// </summary>
    public class InvestigatePerson
    {
        private InvestigatePerson(Guid orderId)
        {
            this.OrderId = orderId;
        }

        /// <summary>
        /// The unique identifier of the Order
        /// </summary>
        public Guid OrderId { get; private set; }

        /// <summary>
        /// Static factory method to create an Investigate Person Order
        /// </summary>
        /// <returns></returns>
        public static InvestigatePerson Create()
        {
            return new InvestigatePerson(Guid.NewGuid());
        }



    }
}
