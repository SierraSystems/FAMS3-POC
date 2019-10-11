using System;
using Automatonymous;
using SearchApi.Core.Contracts;

namespace SearchApi.Tracker.Tracking
{
    /// <summary>
    /// The InvestigationStateMachine orchestrates the Investigation
    /// </summary>
    public class InvestigationStateMachine : MassTransitStateMachine<Investigation>
    {
        public InvestigationStateMachine()
        {

            Event(() => InvestigationOrdered, 
                x => x.CorrelateById(investigation => investigation.CorrelationId, context => context.Message.SearchRequestId)
                .SelectId(context => context.Message.SearchRequestId));

            InstanceState(x => x.CurrentState);

            Initially(
                When(InvestigationOrdered)
                    .Then(context => { context.Instance.SearchRequestId = context.Data.SearchRequestId; })
                    .TransitionTo(SearchPathDetermined));

        }

        public Event<InvestigationOrdered> InvestigationOrdered { get; private set; }

        public State SearchPathDetermined { get; private set; }
    }
}