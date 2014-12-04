using System;
using System.Collections.Generic;
using LdarDataDisplay.Foundation.Factories.ViewModels;
using LdarDataDisplay.Foundation.Models;
using LdarDataDisplay.Foundation.ViewModels;

namespace LdarDataDisplay.Core.Factories.ViewModels
{
    public class DeviceViewModelFactory : IDeviceViewModelFactory
    {
        private readonly Func<ILdarDeviceData, Dictionary<string, DeviceDataConfiguration>,  IDeviceViewModel> createViewModelFunc;

        public DeviceViewModelFactory(Func<ILdarDeviceData, Dictionary<string, DeviceDataConfiguration>,  IDeviceViewModel> createViewModelFunc)
        {
            this.createViewModelFunc = createViewModelFunc;
        }

        public IDeviceViewModel Create(ILdarDeviceData ldarDeviceData, Dictionary<string, DeviceDataConfiguration> deviceDataConfigurations)
        {
            return createViewModelFunc(ldarDeviceData, deviceDataConfigurations);
        }
    }
}