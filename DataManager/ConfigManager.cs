using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DataManager
{
    public static class ConfigManager
    {
        public static Config LoadConfig(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Config>(json);
        }

        public static void SaveConfig(Config config)
        {
            string json = JsonConvert.SerializeObject(config);
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "config.json");
            File.WriteAllText(path, json);
        }
    }
}
