using EDI.In.Scheduler.Endpoints;
using EDI.In.Scheduler.Helpers;
using System;

namespace EDI.In.Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            var setting = Configuration.GetSetting<Setting>();
            var endpoint = new EndpointRunner(setting);
            Console.Title = setting.EndpointName;
            EndpointHost.RunAsConsoleAsync(endpoint).GetAwaiter().GetResult();
        }
    }
}
