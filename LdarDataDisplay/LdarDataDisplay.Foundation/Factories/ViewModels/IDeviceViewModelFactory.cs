﻿using System.Collections.Generic;
using LdarDataDisplay.Foundation.Models;
using LdarDataDisplay.Foundation.ViewModels;

namespace LdarDataDisplay.Foundation.Factories.ViewModels
{
    public interface IDeviceViewModelFactory
    {
        IDeviceViewModel Create(ILdarDeviceData ldarDeviceData, Dictionary<string, DeviceDataConfiguration> deviceDataConfigurations);
    }
}