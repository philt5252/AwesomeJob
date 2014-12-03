using System;
using System.Windows.Input;
using LdarDataDisplay.Foundation.Controllers;
using LdarDataDisplay.Foundation.ViewModels;
using Microsoft.Practices.Prism.Commands;

namespace LdarDataDisplay.Core.ViewModels
{
    public class MainWindowViewModel : ViewModel, IMainWindowViewModel
    {
        private readonly IAppController appController;
        public ICommand ShowScreenLayoutCommand { get; protected set; }

        public MainWindowViewModel(IAppController appController)
        {
            this.appController = appController;
            ShowScreenLayoutCommand = new DelegateCommand(ExecuteShowcreenLayoutCommand);
        }

        private void ExecuteShowcreenLayoutCommand()
        {
            appController.ShowScreenLaout();
        }
    }
}