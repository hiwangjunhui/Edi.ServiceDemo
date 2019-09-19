using EDI.In.Scheduler.Endpoints;
using EDI.In.Scheduler.Helpers;
using EDI.In.Scheduler.Messages.Commands;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace EDI.In.Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var setting = Configuration.GetSetting<Setting>();
            var endpoint = new EndpointRunner(setting);
            Console.Title = setting.EndpointName;
            EndpointHost.RunAsConsoleAsync(endpoint, ScheduleCommand).GetAwaiter().GetResult();
        }

        static async Task ScheduleCommand(IEndpointInstance endpointInstance)
        {
            await endpointInstance.Send(new PollForPurchaseOrders { Id = Guid.NewGuid() }).ConfigureAwait(false);
        }
    }
}
