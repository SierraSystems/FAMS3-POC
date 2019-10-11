using System;
using Newtonsoft.Json;

namespace SearchApi.Core.Contracts
{
    /// <summary>
    /// Represent an order to investigate on a person
    /// </summary>
    public class InvestigatePerson
    {
        [JsonConstructor]
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
