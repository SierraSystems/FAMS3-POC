using System;
using System.Linq;
using System.Threading.Tasks;
using Automatonymous.Testing;
using MassTransit.Testing;
using NUnit.Framework;
using SearchApi.Core.Contracts;
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

            Guid sagaId = Guid.NewGuid();

            await harness.Start();

            try
            {
                await harness.InputQueueSendEndpoint.Send(new InvestigationOrdered()
                {
                    SearchRequestId = sagaId
                });

                Assert.IsTrue(harness.Consumed.Select<InvestigationOrdered>().Any(), "Message not received");

                Investigation instance = saga.Created.Contains(sagaId);
                Assert.IsNotNull(instance, "Saga instance not found");

                Assert.AreEqual(instance.CurrentState,  nameof(_machine.SearchPathDetermined));

            }
            finally
            {
                await harness.Stop();
            }


        }



    }
}