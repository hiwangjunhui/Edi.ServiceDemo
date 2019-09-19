using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

namespace EDI.In.Scheduler.Endpoints
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
