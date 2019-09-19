﻿using EDI.In.Poller.Messages.Commands;
using NServiceBus;
using System.Threading.Tasks;

namespace EDI.In.Poller.Endpoints
{
    sealed class EndpointRunner
    {
        private readonly Setting _setting;
        private IEndpointInstance _instance;

        public EndpointRunner(Setting setting)
        {
            _setting = setting;
        }

        public async Task StartAsync()
        {
            var config = new EndpointConfiguration(_setting.EndpointName);
            config.EnableInstallers();
            config.SendFailedMessagesTo(_setting.ErrorQueue);

            config.UseSerialization<XmlSerializer>();

            var transport = config.UseTransport<RabbitMQTransport>();
            transport.UseConventionalRoutingTopology();
            transport.ConnectionString(_setting.TransportConnection);
            transport.Routing().RouteToEndpoint(typeof(ProcessPurchaseOrder), _setting.DestinationEndpointName);

            config.Recoverability().Delayed(t => t.NumberOfRetries(0));
            _instance = await Endpoint.Start(config);
        }

        public async Task StopAsync()
        {
            await _instance?.Stop();
        }
    }
}
