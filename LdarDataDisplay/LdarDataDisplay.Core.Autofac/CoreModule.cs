using Autofac;
using LdarDataDisplay.Core.Controllers;
using LdarDataDisplay.Core.Factories.ViewModels;
using LdarDataDisplay.Core.ViewModels;
using LdarDataDisplay.Foundation.Controllers;
using LdarDataDisplay.Foundation.Factories.ViewModels;
using LdarDataDisplay.Foundation.ViewModels;

namespace LdarDataDisplay.Core.Autofac
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AppController>().As<IAppController>().SingleInstance();

            builder.RegisterType<MainWindowViewModelFactory>().As<IMainWindowViewModelFactory>().SingleInstance();
            builder.RegisterType<ScreenLayoutViewModelFactory>().As<IScreenLayoutViewModelFactory>().SingleInstance();
            builder.RegisterType<DeviceViewModelFactory>().As<IDeviceViewModelFactory>().SingleInstance();

            builder.RegisterType<MainWindowViewModel>().As<IMainWindowViewModel>();
            builder.RegisterType<ScreenLayoutViewModel>().As<IScreenLayoutViewModel>();
            builder.RegisterType<DeviceViewModel>().As<IDeviceViewModel>();
        }
    }
}