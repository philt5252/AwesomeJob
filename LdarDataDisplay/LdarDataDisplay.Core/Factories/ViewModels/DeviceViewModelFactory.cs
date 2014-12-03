using System;
using LdarDataDisplay.Foundation.Factories.ViewModels;
using LdarDataDisplay.Foundation.Models;
using LdarDataDisplay.Foundation.ViewModels;

namespace LdarDataDisplay.Core.Factories.ViewModels
{
    public class DeviceViewModelFactory : IDeviceViewModelFactory
    {
        private readonly Func<ILdarDeviceData, IDeviceViewModel> createViewModelFunc;

        public DeviceViewModelFactory(Func<ILdarDeviceData, IDeviceViewModel> createViewModelFunc)
        {
            this.createViewModelFunc = createViewModelFunc;
        }

        public IDeviceViewModel Create(ILdarDeviceData ldarDeviceData)
        {
            return createViewModelFunc(ldarDeviceData);
        }
    }
}