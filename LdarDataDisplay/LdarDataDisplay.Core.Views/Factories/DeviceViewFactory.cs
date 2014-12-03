using System;
using LdarDataDisplay.Foundation.Views;
using LdarDataDisplay.Foundation.Views.Factories;

namespace LdarDataDisplay.Core.Views.Factories
{
    public class DeviceViewFactory : IDeviceViewFactory
    {
        private readonly Func<DeviceView> createViewFunc;

        public DeviceViewFactory(Func<DeviceView> createViewFunc )
        {
            this.createViewFunc = createViewFunc;
        }

        public IViewWithDataContext Create()
        {
            return createViewFunc();
        }
    }
}