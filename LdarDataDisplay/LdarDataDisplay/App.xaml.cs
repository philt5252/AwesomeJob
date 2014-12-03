using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Autofac;
using LdarDataDisplay.Core.Autofac;
using LdarDataDisplay.Core.DataAccess.Autofac;
using LdarDataDisplay.Core.Views.Autofac;
using LdarDataDisplay.Foundation.Controllers;
using Microsoft.Practices.ServiceLocation;
using Olf.Prism.Autofac;

namespace LdarDataDisplay
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<DataAccessModule>();
            builder.RegisterModule<ViewsModule>();
            builder.RegisterModule<PrismModule>();

            IContainer container = builder.Build();

            IServiceLocator serviceLocator = container.Resolve<IServiceLocator>();

            ServiceLocator.SetLocatorProvider(() => serviceLocator);

            IAppController appController;

            using(var scope = container.BeginLifetimeScope())
            {
                appController = scope.Resolve<IAppController>();
            }

            appController.Home();
        }
    }
}
