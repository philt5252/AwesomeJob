using System.Collections.Generic;
using LdarDataDisplay.Foundation.Annotations;
using LdarDataDisplay.Foundation.Models;

namespace LdarDataDisplay.Foundation.DataAccess
{
    public interface IConfigurationRepository
    {
        void Save(DeviceDataConfiguration[] configs);
        Dictionary<string, DeviceDataConfiguration> Open();
    }
}