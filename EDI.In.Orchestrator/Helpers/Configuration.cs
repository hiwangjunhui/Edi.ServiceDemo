using Microsoft.Extensions.Configuration;
using System;

namespace EDI.In.Orchestrator.Helpers
{
    public static class Configuration
    {
        private static IConfigurationRoot _root = null;
        private static readonly object _lock = new object();

        public static T GetSetting<T>() where T : new()
        {
            var section = Root.GetSection(typeof(T).Name);
            var setting = new T();
            section.Bind(setting);
            return setting;
        }

        public static IConfigurationRoot Root {
            get
            {
                if (null == _root)
                {
                    lock (_lock)
                    {
                        if (null== _root)
                        {
                            _root = BuildRootConfiguration();
                        }
                    }
                }

                return _root;
            }
        }

        private static IConfigurationRoot BuildRootConfiguration()
        {
            var env = Environment.GetEnvironmentVariable(Resources.ConfigurationResource.EnvironmentVariable);
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(Resources.ConfigurationResource.DefaultJsonFile, false, true)
                .AddJsonFile(string.Format(Resources.ConfigurationResource.EnvironmentJsonFile, env), true, true)
                .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
