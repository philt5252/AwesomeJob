using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LdarDataDisplay.Foundation.DataAccess;
using LdarDataDisplay.Foundation.Models;

namespace LdarDataDisplay.Core.DataAccess
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private string filename = "LdarDeviceConfig.cfg";
        
        public void Save(DeviceDataConfiguration[] configs)
        {
            string filePath = GetFilePath();

            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, configs);

            fileStream.Dispose();
        }

        public Dictionary<string, DeviceDataConfiguration> Open()
        {
            string filePath = GetFilePath();
            Dictionary<string, DeviceDataConfiguration> configs = new Dictionary<string, DeviceDataConfiguration>();

            if (!File.Exists(filePath))
            {
                string[] properties = new[] {"LPH2"};

                foreach (var property in properties)
                {
                    configs[property] = new DeviceDataConfiguration {DataName = property};
                }

                return configs;
            }

            BinaryFormatter formatter = new BinaryFormatter();
            var deviceDataConfigurations = formatter.Deserialize(new FileStream(filePath, FileMode.Open)) as DeviceDataConfiguration[];

            
            foreach (var deviceDataConfiguration in deviceDataConfigurations)
            {
                configs[deviceDataConfiguration.DataName] = deviceDataConfiguration;
            }

            return configs;
        }

        protected string GetFilePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), filename);
        }
    }
}