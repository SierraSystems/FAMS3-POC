using System;
using System.Threading.Tasks;
using MassTransit;
using SearchApi.Core.Contracts;

namespace SearchApi.Tracker
{
    public class InvestigatePersonConsumer : IConsumer<InvestigatePerson>
    {

        public async Task Consume(ConsumeContext<InvestigatePerson> context)
        {
            await Console.Out.WriteLineAsync($"Updating customer: {context.Message.OrderId}");
        }


    }
}