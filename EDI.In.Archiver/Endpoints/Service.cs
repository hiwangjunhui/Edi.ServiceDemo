using System.ServiceProcess;
using NServiceBus;

namespace EDI.In.Archiver.Endpoints
{
    partial class Service : ServiceBase
    {
        private readonly EndpointRunner _endpointRunner;
        public Service(EndpointRunner endpointRunner)
        {
            InitializeComponent();
            _endpointRunner = endpointRunner;
        }

        protected override void OnStart(string[] args)
        {
            _endpointRunner.StartAsync().GetAwaiter().GetResult();
        }

        protected override void OnStop()
        {
            _endpointRunner.StopAsync().GetAwaiter().GetResult();
        }
    }
}
