using System;
using NServiceBus;

namespace EDI.In.Orchestrator.Handlers
{
    public class State : ContainSagaData
    {
        public Guid ProcessId { get; set; }
    }
}
