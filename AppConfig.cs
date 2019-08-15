using Json.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace product_manager
{
    public class AppConfig
    {
        public string DbConnectionString { get; set; }

        public static AppConfig GetAppConfig()
        {
            string configFilePath = Directory.GetCurrentDirectory() + "\\app_config.json";
            string configJson = File.ReadAllText(configFilePath, Encoding.UTF8);
            AppConfig appConfig = JsonConvert.DeserializeObject<AppConfig>(configJson);
            return appConfig;
        }
    }
}
