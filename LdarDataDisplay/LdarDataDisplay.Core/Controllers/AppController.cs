using System.Linq;
using LdarDataDisplay.Foundation.Controllers;
using LdarDataDisplay.Foundation.DataAccess;
using LdarDataDisplay.Foundation.Factories.ViewModels;
using LdarDataDisplay.Foundation.Models;
using LdarDataDisplay.Foundation.ViewModels;
using LdarDataDisplay.Foundation.Views;
using LdarDataDisplay.Foundation.Views.Factories;
using Microsoft.Practices.Prism.Regions;

namespace LdarDataDisplay.Core.Controllers
{
    public class AppController : IAppController
    {
        private readonly IMainWindowFactory mainWindowFactory;
        private readonly IScreenLayoutWindowFactory screenLayoutWindowFactory;
        private readonly IDeviceViewFactory deviceViewFactory;
        private readonly IMainWindowViewModelFactory mainWindowViewModelFactory;
        private readonly IScreenLayoutViewModelFactory screenLayoutViewModelFactory;
        private readonly IDeviceViewModelFactory deviceViewModelFactory;
        private readonly ILdarDeviceRepository ldarDeviceRepository;
        private readonly IRegionManager regionManager;

        public AppController(IMainWindowFactory mainWindowFactory,
            IScreenLayoutWindowFactory screenLayoutWindowFactory,
            IDeviceViewFactory deviceViewFactory,
            IMainWindowViewModelFactory mainWindowViewModelFactory,
            IScreenLayoutViewModelFactory screenLayoutViewModelFactory,
            IDeviceViewModelFactory deviceViewModelFactory,
            ILdarDeviceRepository ldarDeviceRepository,
            IRegionManager regionManager)
        {
            this.mainWindowFactory = mainWindowFactory;
            this.screenLayoutWindowFactory = screenLayoutWindowFactory;
            this.deviceViewFactory = deviceViewFactory;
            this.mainWindowViewModelFactory = mainWindowViewModelFactory;
            this.screenLayoutViewModelFactory = screenLayoutViewModelFactory;
            this.deviceViewModelFactory = deviceViewModelFactory;
            this.ldarDeviceRepository = ldarDeviceRepository;
            this.regionManager = regionManager;
        }

        public void Home()
        {
            ILdarDeviceData[] ldarDeviceDatas = ldarDeviceRepository.RetrieveData();

            IDeviceViewModel[] deviceViewModels = ldarDeviceDatas.Select(d => deviceViewModelFactory.Create(d)).ToArray();

            IViewWithDataContext[] deviceViews = deviceViewModels.Select(d =>
            {
                IViewWithDataContext deviceView = deviceViewFactory.Create();
                deviceView.DataContext = d;

                return deviceView;
            }).ToArray();

            IMainWindowViewModel mainWindowViewModel = mainWindowViewModelFactory.Create();
            IWindow mainWindow = mainWindowFactory.Create();

            mainWindow.DataContext = mainWindowViewModel;

            mainWindow.Show();

            foreach (var deviceView in deviceViews)
            {
                regionManager.Regions["DeviceRegion"].Add(deviceView);
                regionManager.Regions["DeviceRegion"].Activate(deviceView);
            }
           
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