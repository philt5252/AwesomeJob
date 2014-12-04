using System.Collections.Generic;
using LdarDataDisplay.Foundation.Models;
using LdarDataDisplay.Foundation.ViewModels;

namespace LdarDataDisplay.Foundation.Factories.ViewModels
{
    public interface IScreenLayoutViewModelFactory
    {
        IScreenLayoutViewModel Create(Dictionary<string, DeviceDataConfiguration> deviceDataConfigurations);
    }
}