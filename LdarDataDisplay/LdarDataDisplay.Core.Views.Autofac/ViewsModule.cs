using Autofac;
using LdarDataDisplay.Core.Views.Factories;
using LdarDataDisplay.Foundation.Views.Factories;

namespace LdarDataDisplay.Core.Views.Autofac
{
    public class ViewsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<MainWindowFactory>().As<IMainWindowFactory>().SingleInstance();
            builder.RegisterType<ScreenLayoutWindowFactory>().As<IScreenLayoutWindowFactory>().SingleInstance();

            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<ScreenLayoutWindow>().AsSelf();
        }
    }
}