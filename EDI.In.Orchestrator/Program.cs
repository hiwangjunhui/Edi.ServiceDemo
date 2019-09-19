using EDI.In.Orchestrator.Endpoints;
using EDI.In.Orchestrator.Helpers;
using System;

namespace EDI.In.Orchestrator
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
