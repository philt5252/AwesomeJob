using System;
using System.Collections.Generic;
using LdarDataDisplay.Foundation.Factories.ViewModels;
using LdarDataDisplay.Foundation.Models;
using LdarDataDisplay.Foundation.ViewModels;

namespace LdarDataDisplay.Core.Factories.ViewModels
{
    public class ScreenLayoutViewModelFactory : IScreenLayoutViewModelFactory
    {
        private readonly Func<Dictionary<string, DeviceDataConfiguration>, IScreenLayoutViewModel> createViewModelFunc;

        public ScreenLayoutViewModelFactory(Func<Dictionary<string, DeviceDataConfiguration>, IScreenLayoutViewModel> createViewModelFunc )
        {
            this.createViewModelFunc = createViewModelFunc;
        }

        public IScreenLayoutViewModel Create(Dictionary<string, DeviceDataConfiguration> deviceDataConfigurations)
        {
            return createViewModelFunc(deviceDataConfigurations);
        }
    }
}