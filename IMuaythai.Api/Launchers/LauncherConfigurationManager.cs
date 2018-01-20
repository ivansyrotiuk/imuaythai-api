using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace IMuaythai.Api.Launchers
{
    public class LauncherConfigurationManager
    {
        public static void CreateLocalInstanseConfiguration()
        {
            const string settingsFile = "appsettings.json";
            if (!File.Exists(settingsFile))
            {
                Console.WriteLine("Configuration file is not existed.");
                Console.ReadKey();
                return;
            }

            var json = File.ReadAllText(settingsFile);
            var configuration = JObject.Parse(json);
            var connectionStrings = configuration["ConnectionStrings"];
            connectionStrings["DefaultConnection"] = $"Server=(localdb)\\MSSQLLocalDB;Database=imuaythai_local_contest_{DateTime.Now.Ticks};Trusted_Connection=True;";
            json = configuration.ToString();
            File.WriteAllText(settingsFile, json);
        }
    }
}