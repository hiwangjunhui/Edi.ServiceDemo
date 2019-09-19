using EDI.In.Archiver.Endpoints;
using EDI.In.Archiver.Helpers;
using System;

namespace EDI.In.Archiver
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
