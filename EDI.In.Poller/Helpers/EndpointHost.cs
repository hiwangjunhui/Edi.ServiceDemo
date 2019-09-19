using Microsoft.Extensions.Hosting;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace EDI.In.Poller.Helpers
{
    static class EndpointHost
    {
        public static async Task RunAsConsoleAsync(Endpoints.EndpointRunner endpointRunner)
        {
            await endpointRunner.StartAsync();
            await new HostBuilder().RunConsoleAsync();
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
