using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Autofac;
using LdarDataDisplay.Core.Autofac;
using LdarDataDisplay.Core.DataAccess.Autofac;
using LdarDataDisplay.Core.Views.Autofac;
using LdarDataDisplay.Foundation.Controllers;
using LdarDataDisplay.Prism.Autofac;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Regions.Behaviors;
using Microsoft.Practices.ServiceLocation;

namespace LdarDataDisplay
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<DataAccessModule>();
            builder.RegisterModule<ViewsModule>();
            builder.RegisterModule<PrismModule>();

            builder.RegisterType<AutofacServiceLocator>().As<IServiceLocator>().SingleInstance();

            container = builder.Build();

            IServiceLocator serviceLocator = container.Resolve<IServiceLocator>();

            ServiceLocator.SetLocatorProvider(() => serviceLocator);

            container.RegisterAllFuncsAsOwned();

            ConfigureDefaultRegionBehaviors();
            ConfigureRegionAdapterMappings();

            IAppController appController;

            using(var scope = container.BeginLifetimeScope())
            {
                appController = scope.Resolve<IAppController>();
            }

            appController.Home();
        }

        protected virtual RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var regionAdapterMappings = container.ResolveOptional<RegionAdapterMappings>();

            if (regionAdapterMappings != null)
            {
                regionAdapterMappings.RegisterMapping(typeof(Selector), container.Resolve<SelectorRegionAdapter>());
                regionAdapterMappings.RegisterMapping(typeof(StackPanel), container.Resolve<ItemsControlRegionAdapter>());
                regionAdapterMappings.RegisterMapping(typeof(ItemsControl), container.Resolve<ItemsControlRegionAdapter>());
                regionAdapterMappings.RegisterMapping(typeof(ContentControl), container.Resolve<ContentControlRegionAdapter>());
                //regionAdapterMappings.RegisterMapping(typeof(LayoutAnchorablePane), container.Resolve<LayoutAnchorablePaneRegionAdapter>());
                //regionAdapterMappings.RegisterMapping(typeof(LayoutDocumentPane), container.Resolve<LayoutDocumentPaneRegionAdapter>());
            }

            return regionAdapterMappings;
        }

        private void ConfigureDefaultRegionBehaviors()
        {
            IRegionBehaviorFactory defaultRegionBehaviorTypesDictionary;
            container.TryResolve(out defaultRegionBehaviorTypesDictionary);

            if (defaultRegionBehaviorTypesDictionary != null)
            {
                defaultRegionBehaviorTypesDictionary.AddIfMissing(AutoPopulateRegionBehavior.BehaviorKey,
                    typeof(AutoPopulateRegionBehavior));

                defaultRegionBehaviorTypesDictionary.AddIfMissing(BindRegionContextToDependencyObjectBehavior.BehaviorKey,
                    typeof(BindRegionContextToDependencyObjectBehavior));

                defaultRegionBehaviorTypesDictionary.AddIfMissing(RegionActiveAwareBehavior.BehaviorKey,
                    typeof(RegionActiveAwareBehavior));

                defaultRegionBehaviorTypesDictionary.AddIfMissing(SyncRegionContextWithHostBehavior.BehaviorKey,
                    typeof(SyncRegionContextWithHostBehavior));

                defaultRegionBehaviorTypesDictionary.AddIfMissing(RegionManagerRegistrationBehavior.BehaviorKey,
                    typeof(RegionManagerRegistrationBehavior));

            }
        }
    }
}
