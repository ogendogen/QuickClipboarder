using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DataManager
{
    internal class ConfigManager
    {
        private string _path;

        internal ConfigManager(string path)
        {
            _path = path;
        }
        internal Config LoadConfig()
        {
            string json = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<Config>(json);
        }
        internal void SaveConfig(Config config)
        {
            string json = JsonConvert.SerializeObject(config);
            File.WriteAllText(_path, json);
        }
    }
}
