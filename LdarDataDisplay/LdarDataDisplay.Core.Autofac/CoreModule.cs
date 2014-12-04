using Autofac;
using LdarDataDisplay.Core.Controllers;
using LdarDataDisplay.Core.Factories.Models;
using LdarDataDisplay.Core.Factories.ViewModels;
using LdarDataDisplay.Core.Models;
using LdarDataDisplay.Core.Services;
using LdarDataDisplay.Core.ViewModels;
using LdarDataDisplay.Foundation.Controllers;
using LdarDataDisplay.Foundation.Factories.Models;
using LdarDataDisplay.Foundation.Factories.ViewModels;
using LdarDataDisplay.Foundation.Models;
using LdarDataDisplay.Foundation.Services;
using LdarDataDisplay.Foundation.ViewModels;

namespace LdarDataDisplay.Core.Autofac
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AppController>().As<IAppController>().SingleInstance();

            builder.RegisterType<LdarDeviceDataFactory>().As<ILdarDeviceDataFactory>().SingleInstance();

            builder.RegisterType<MainWindowViewModelFactory>().As<IMainWindowViewModelFactory>().SingleInstance();
            builder.RegisterType<ScreenLayoutViewModelFactory>().As<IScreenLayoutViewModelFactory>().SingleInstance();
            builder.RegisterType<DeviceViewModelFactory>().As<IDeviceViewModelFactory>().SingleInstance();

            builder.RegisterType<LdarDeviceData>().As<ILdarDeviceData>();

            builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>();
            builder.RegisterType<ScreenLayoutViewModel>().As<IScreenLayoutViewModel>();
            builder.RegisterType<DeviceViewModel>().As<IDeviceViewModel>();

            builder.RegisterType<DataRetrieverService>().As<IDataRetrieverService>().SingleInstance();
        }
    }
}