using System;

namespace EDI.In.Poller.Endpoints
{
    public sealed class Setting
    {
        public string EndpointName { get; set; }

        public string ErrorQueue { get; set; }

        public string PersistenceConnection { get; set; }

        public string TransportConnection { get; set; }

        public string PurchaseOrderConnection { get; set; }

        public string DestinationEndpointName { get; set; }
    }
}
