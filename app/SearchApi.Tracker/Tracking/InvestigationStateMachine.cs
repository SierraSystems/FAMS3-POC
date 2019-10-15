using System;
using Automatonymous;
using SearchApi.Core.Contracts;
using SearchApi.Core.Contracts.PersonSearch;

namespace SearchApi.Tracker.Tracking
{
    /// <summary>
    /// The InvestigationStateMachine orchestrates the Investigation
    /// </summary>
    public class InvestigationStateMachine : MassTransitStateMachine<Investigation>
    {
        public InvestigationStateMachine()
        {

            Event(() => SearchRequested , 
                x => x.CorrelateById(searchRequested => searchRequested.CorrelationId, context => context.Message.CorrelationId)
                .SelectId(context => context.Message.CorrelationId));

            InstanceState(x => x.CurrentState);

            Initially(
                When(SearchRequested)
                    .Then(context =>
                    {
                        context.Instance.SearchRequestId = context.Data.CorrelationId; 
                        Console.WriteLine($"SearchRequeted: {context.Data.CorrelationId}");
                    })
                    .TransitionTo(Started));

        }

        public Event<SearchRequested> SearchRequested { get; private set; }

        public State Started { get; private set; }
    }
}