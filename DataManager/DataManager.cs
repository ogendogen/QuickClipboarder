using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Models;

namespace DataManager
{
    public class DataManager
    {
        public Config Config { get; set; }
        internal ConfigManager ConfigManager { get; set; }
        private string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QuickClipboarder", "config.json");
        public DataManager()
        {
            ConfigManager = new ConfigManager(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QuickClipboarder", "config.json"));

            if (!IsAppInstalled())
            {
                InstallApp();
            }

            Config = ConfigManager.LoadConfig();
        }

        private void InstallApp()
        {
            ConfigManager.SaveConfig(Config);
        }

        private bool IsAppInstalled()
        {
            return File.Exists(_path);
        }
    }
}
