using System;
using System.Collections.Generic;
using System.Text;

namespace EDI.In.Orchestrator.Messages.Policies
{
    public class IntegrationWarningPolicy
    {
        public Guid Id { get; set; }

        public ushort TimeoutMinutes { get; set; }
    }
}
