using System;

namespace EDI.In.Scheduler.Endpoints
{
    public sealed class Setting
    {
        public string EndpointName { get; set; }

        public string ErrorQueue { get; set; }

        public string PersistenceConnection { get; set; }

        public string TransportConnection { get; set; }

        public string ServiceInstance { get; set; }

        public TimeSpan CircuitBreakerTimeoutTimeSpan { get; set; }

        public TimeSpan SubscriptionCacheTimeSpan { get; set;}

        public string IntermediaryConnection { get; set; }
        public TimeSpan CustomCheckTimeSpan { get; set; }
    }
}
