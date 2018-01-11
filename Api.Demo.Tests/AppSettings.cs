using System.Configuration;

namespace Api.Demo.Tests
{
    [System.Diagnostics.DebuggerNonUserCodeAttribute]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute]
    public static class AppSettings
    {
        public static class Es
        {
            public static class Endpoint
            {
                public static string Url
                {
                    get { return ConfigurationManager.AppSettings["es.endpoint.url"]; }
                }
            }

            public static class Index
            {
                public static string Name
                {
                    get { return ConfigurationManager.AppSettings["es.index.name"]; }
                }
            }

            public static class Type
            {
                public static string Name
                {
                    get { return ConfigurationManager.AppSettings["es.type.name"]; }
                }
            }
        }
    }
}

