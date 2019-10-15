using System;
using Automatonymous;

namespace SearchApi.Tracker.Tracking
{
    /// <summary>
    /// Represents an Investigation on a given subject
    /// </summary>
    public class Investigation : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }

        public String CurrentState { get; set; }

        public Guid SearchRequestId { get; set; }

    }
}