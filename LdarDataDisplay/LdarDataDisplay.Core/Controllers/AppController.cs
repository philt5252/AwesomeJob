using LdarDataDisplay.Foundation.Controllers;
using LdarDataDisplay.Foundation.Factories.ViewModels;
using LdarDataDisplay.Foundation.ViewModels;
using LdarDataDisplay.Foundation.Views;
using LdarDataDisplay.Foundation.Views.Factories;

namespace LdarDataDisplay.Core.Controllers
{
    public class AppController : IAppController
    {
        private readonly IMainWindowFactory mainWindowFactory;
        private readonly IScreenLayoutWindowFactory screenLayoutWindowFactory;
        private readonly IMainWindowViewModelFactory mainWindowViewModelFactory;
        private readonly IScreenLayoutViewModelFactory screenLayoutViewModelFactory;

        public AppController(IMainWindowFactory mainWindowFactory,
            IScreenLayoutWindowFactory screenLayoutWindowFactory,
            IMainWindowViewModelFactory mainWindowViewModelFactory,
            IScreenLayoutViewModelFactory screenLayoutViewModelFactory)
        {
            this.mainWindowFactory = mainWindowFactory;
            this.screenLayoutWindowFactory = screenLayoutWindowFactory;
            this.mainWindowViewModelFactory = mainWindowViewModelFactory;
            this.screenLayoutViewModelFactory = screenLayoutViewModelFactory;
        }

        public void Home()
        {
            IMainWindowViewModel mainWindowViewModel = mainWindowViewModelFactory.Create();
            IWindow mainWindow = mainWindowFactory.Create();

            mainWindow.DataContext = mainWindowViewModel;

            mainWindow.Show();
        }

        public void ShowScreenLaout()
        {
            IScreenLayoutViewModel screenLayoutViewModel = screenLayoutViewModelFactory.Create();
            IWindow configurationWindow = screenLayoutWindowFactory.Create();

            configurationWindow.DataContext = screenLayoutViewModel;

            configurationWindow.Show();
        }
    }
}