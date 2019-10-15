using System;
using System.Linq;
using System.Threading.Tasks;
using Automatonymous.Testing;
using MassTransit.Testing;
using NUnit.Framework;
using SearchApi.Core.Contracts;
using SearchApi.Core.Contracts.PersonSearch;
using SearchApi.Tracker.Tracking;

namespace SearchApi.Tracker.Test.Tracking
{
    public class InvestigationStateMachineTest
    {

        InvestigationStateMachine _machine;


        [Test]
        public async Task should_handle_the_initial_state()
        {

            var harness = new InMemoryTestHarness();

            _machine = new InvestigationStateMachine();

            StateMachineSagaTestHarness<Investigation, InvestigationStateMachine> saga = harness.StateMachineSaga<Investigation, InvestigationStateMachine>(_machine);


            await harness.Start();

            var searchRequestedEvent = SearchRequested.Create();

            try
            {
                await harness.InputQueueSendEndpoint.Send(searchRequestedEvent);

                Assert.IsTrue(harness.Consumed.Select<SearchRequested>().Any(), "Message not received");

                Investigation instance = saga.Created.Select(x => x.CorrelationId == searchRequestedEvent.CorrelationId)
                    .FirstOrDefault()
                    ?.Saga;
                Assert.IsNotNull(instance, "Saga instance not found");

                Assert.AreEqual(instance.CurrentState,  nameof(_machine.Started));

            }
            finally
            {
                await harness.Stop();
            }


        }



    }
}