using EDI.In.Poller.Endpoints;
using EDI.In.Poller.Helpers;
using System;

namespace EDI.In.Poller
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
