using System;

namespace SearchApi.Core.Contracts
{
    public interface InvestigationOrdered
    {
        Guid SearchRequestId { get; }
    }
}