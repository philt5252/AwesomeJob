// Type: Olf.Prism.Autofac.PrismModule
// Assembly: Olf.Prism.Autofac, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B602AB0F-421B-4BF7-B23C-1730E3BFE3FA
// Assembly location: C:\Users\ptrevino\Desktop\CryptoObfuscateTest\CryptoObfuscator_Output\Olf.Prism.Autofac.dll

using Autofac;
using Autofac.Builder;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Regions.Behaviors;

namespace LdarDataDisplay.Prism.Autofac
{
  public class PrismModule : Module
  {
    public PrismModule()
    {
    }

    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);
      this.ConfigureContainer(builder);
      PrismModule.RegisterComponentContext(builder);
    }

    private static void RegisterComponentContext(ContainerBuilder builder)
    {
    }

    protected virtual void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterType<AutofacServiceLocator>().SingleInstance();

        //builder.RegisterType<RegionManagerAutoMapHelper>().AsSelf().SingleInstance().PreserveExistingDefaults();
        builder.RegisterType<RegionAdapterMappings>().AsSelf().InstancePerLifetimeScope().PreserveExistingDefaults();
        builder.RegisterType<RegionViewRegistry>().As<IRegionViewRegistry>().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();
        builder.RegisterType<RegionBehaviorFactory>().As<IRegionBehaviorFactory>().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();
        builder.RegisterType<TraceLogger>().As<ILoggerFacade>().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();
        builder.RegisterType<EventAggregator>().As<IEventAggregator>().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();
        builder.RegisterType<RegionManager>().As<IRegionManager>().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();//.InstancePerLifetimeScope().PreserveExistingDefaults();
        builder.RegisterType<SelectorRegionAdapter>().AsSelf().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();
        builder.RegisterType<ItemsControlRegionAdapter>().AsSelf().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();
        builder.RegisterType<ContentControlRegionAdapter>().AsSelf().ExternallyOwned().InstancePerLifetimeScope().PreserveExistingDefaults();

        builder.RegisterType<DelayedRegionCreationBehavior>().AsSelf().ExternallyOwned().InstancePerDependency().PreserveExistingDefaults();
        builder.RegisterType<AutoPopulateRegionBehavior>().AsSelf().ExternallyOwned().InstancePerDependency().PreserveExistingDefaults();
        builder.RegisterType<BindRegionContextToDependencyObjectBehavior>().AsSelf().ExternallyOwned().InstancePerDependency().PreserveExistingDefaults();
        builder.RegisterType<RegionActiveAwareBehavior>().AsSelf().ExternallyOwned().InstancePerDependency().PreserveExistingDefaults();
        builder.RegisterType<SyncRegionContextWithHostBehavior>().AsSelf().ExternallyOwned().InstancePerDependency().PreserveExistingDefaults();
        builder.RegisterType<RegionManagerRegistrationBehavior>().AsSelf().ExternallyOwned().InstancePerDependency().PreserveExistingDefaults();

        builder.RegisterType<ModuleInitializer>().As<IModuleInitializer>().ExternallyOwned()
            .InstancePerLifetimeScope().PreserveExistingDefaults();
        builder.RegisterType<ModuleManager>().As<IModuleManager>().ExternallyOwned().InstancePerLifetimeScope()
            .PreserveExistingDefaults();
    }
  }
}
