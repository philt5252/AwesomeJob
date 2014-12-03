using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Autofac;
using LdarDataDisplay.Core.Autofac;
using LdarDataDisplay.Core.Views.Autofac;
using LdarDataDisplay.Foundation.Controllers;

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
            builder.RegisterModule<ViewsModule>();

            IContainer container = builder.Build();

            IAppController appController;

            using(var scope = container.BeginLifetimeScope())
            {
                appController = scope.Resolve<IAppController>();
            }

            appController.Home();
        }
    }
}
