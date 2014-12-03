using System;
using LdarDataDisplay.Foundation.Views;
using LdarDataDisplay.Foundation.Views.Factories;

namespace LdarDataDisplay.Core.Views.Factories
{
    public class ScreenLayoutWindowFactory : IScreenLayoutWindowFactory
    {
        private readonly Func<ScreenLayoutWindow> createWindowFunc;

        public ScreenLayoutWindowFactory(Func<ScreenLayoutWindow> createWindowFunc )
        {
            this.createWindowFunc = createWindowFunc;
        }

        public IWindow Create()
        {
            return createWindowFunc();
        }
    }
}