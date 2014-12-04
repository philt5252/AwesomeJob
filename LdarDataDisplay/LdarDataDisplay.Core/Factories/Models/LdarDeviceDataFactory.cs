using System;
using LdarDataDisplay.Foundation.Factories.Models;
using LdarDataDisplay.Foundation.Models;

namespace LdarDataDisplay.Core.Factories.Models
{
    public class LdarDeviceDataFactory : ILdarDeviceDataFactory
    {
        private readonly Func<ILdarDeviceData> createModelFunc;

        public LdarDeviceDataFactory(Func<ILdarDeviceData> createModelFunc)
        {
            this.createModelFunc = createModelFunc;
        }

        public ILdarDeviceData Create()
        {
            return createModelFunc();
        }
    }
}