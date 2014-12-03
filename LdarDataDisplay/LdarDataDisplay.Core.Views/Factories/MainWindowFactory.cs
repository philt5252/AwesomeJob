using System;
using LdarDataDisplay.Foundation.Views;
using LdarDataDisplay.Foundation.Views.Factories;

namespace LdarDataDisplay.Core.Views.Factories
{
    public class MainWindowFactory : IMainWindowFactory
    {
        private readonly Func<MainWindow> createWindowFunc;

        public MainWindowFactory(Func<MainWindow> createWindowFunc )
        {
            this.createWindowFunc = createWindowFunc;
        }

        public IWindow Create()
        {
            return createWindowFunc();
        }
    }
}