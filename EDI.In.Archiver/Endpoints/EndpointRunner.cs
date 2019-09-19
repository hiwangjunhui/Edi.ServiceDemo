using NServiceBus;
using System.Threading.Tasks;
using Autofac;
using System.Reflection;

namespace EDI.In.Archiver.Endpoints
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

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<Repositories.DbHelper>().As<Repositories.IDbHelper>();
            config.UseContainer<AutofacBuilder>(t => t.ExistingLifetimeScope(containerBuilder.Build()));

            var transport = config.UseTransport<RabbitMQTransport>();
            transport.UseConventionalRoutingTopology();
            transport.ConnectionString(_setting.TransportConnection);

            config.Recoverability().Delayed(t => t.NumberOfRetries(0));
            _instance = await Endpoint.Start(config);
        }

        public async Task StopAsync()
        {
            await _instance?.Stop();
        }
    }
}
