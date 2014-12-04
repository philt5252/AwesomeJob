using Autofac;
using LdarDataDisplay.Foundation.DataAccess;

namespace LdarDataDisplay.Core.DataAccess.Autofac
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<LdarDeviceRepository>().As<ILdarDeviceRepository>().SingleInstance();
            builder.RegisterType<ConfigurationRepository>().As<IConfigurationRepository>().SingleInstance();

        }
    }
}