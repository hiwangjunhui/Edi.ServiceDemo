using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using NServiceBus;

namespace EDI.In.Scheduler.Helpers
{
    static class EndpointHost
    {
        public static async Task RunAsConsoleAsync(Endpoints.EndpointRunner endpointRunner, Func<IEndpointInstance, Task> commandSchedule)
        {
            await endpointRunner.StartAsync();

            if (null == commandSchedule)
            {
                commandSchedule = instance => new HostBuilder().RunConsoleAsync();
            }

            await commandSchedule(endpointRunner.Instance);
            await endpointRunner.StopAsync();
        }

        public static Task RunAsServiceAsync(Endpoints.EndpointRunner endpointRunner)
        {
            using (var service = new Endpoints.Service(endpointRunner))
            {
                ServiceBase.Run(service);
                return Task.CompletedTask;
            }
        }
    }
}
