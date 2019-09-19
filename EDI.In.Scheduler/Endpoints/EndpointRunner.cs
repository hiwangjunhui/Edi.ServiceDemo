using EDI.In.Scheduler.Messages.Commands;
using NServiceBus;
using System.Threading.Tasks;

namespace EDI.In.Scheduler.Endpoints
{
    sealed class EndpointRunner
    {
        private readonly Setting _setting;

        public EndpointRunner(Setting setting)
        {
            _setting = setting;
        }

        public IEndpointInstance Instance { get; private set; }

        public async Task StartAsync()
        {
            var config = new EndpointConfiguration(_setting.EndpointName);
            config.EnableInstallers();
            config.SendFailedMessagesTo(_setting.ErrorQueue);

            config.UseSerialization<XmlSerializer>();

            var transport = config.UseTransport<RabbitMQTransport>();
            transport.UseConventionalRoutingTopology();
            transport.ConnectionString(_setting.TransportConnection);
            transport.Routing().RouteToEndpoint(typeof(PollForPurchaseOrders), _setting.DestinationEndpointName);

            config.Recoverability().Delayed(t => t.NumberOfRetries(0));
            Instance = await Endpoint.Start(config);
        }

        public async Task StopAsync()
        {
            await Instance?.Stop();
        }
    }
}
