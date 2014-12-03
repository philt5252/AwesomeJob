using System;
using LdarDataDisplay.Foundation.Factories.ViewModels;
using LdarDataDisplay.Foundation.ViewModels;
using LdarDataDisplay.Foundation.Views;
using LdarDataDisplay.Foundation.Views.Factories;

namespace LdarDataDisplay.Core.Factories.ViewModels
{
    public class MainWindowViewModelFactory : IMainWindowViewModelFactory
    {
        private readonly Func<IMainWindowViewModel> createViewModelFunc;

        public MainWindowViewModelFactory(Func<IMainWindowViewModel> createViewModelFunc)
        {
            this.createViewModelFunc = createViewModelFunc;
        }

        public IMainWindowViewModel Create()
        {
            return createViewModelFunc();
        }
    }
}