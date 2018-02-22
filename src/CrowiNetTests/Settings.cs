using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace CrowiNetTests
{
    internal static class Settings
    {
        private static readonly IConfiguration Configuration = 
            new ConfigurationBuilder()
                .SetBasePath( Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) )
                .AddJsonFile("settings.json")
                .Build();

        internal static string EndPoint => Configuration["endPoint"];
        internal static string User => Configuration["user"];
        internal static string AccessToken => Configuration["accessToken"];
    }
}
