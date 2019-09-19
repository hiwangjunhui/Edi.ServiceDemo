using System;

namespace EDI.In.Orchestrator.Endpoints
{
    public sealed class Setting
    {
        public string EndpointName { get; set; }

        public string ErrorQueue { get; set; }

        public ushort SagaRequestTimeoutMinutes { get; set; }

        public string TransportConnection { get; set; }

        public string DestinationEndpointName { get; set; }
    }
}
