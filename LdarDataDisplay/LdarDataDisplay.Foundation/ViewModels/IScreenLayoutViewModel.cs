using System.ComponentModel;
using System.Windows.Input;
using LdarDataDisplay.Foundation.Models;

namespace LdarDataDisplay.Foundation.ViewModels
{
    public interface IScreenLayoutViewModel : INotifyPropertyChanged
    {
        DeviceDataConfiguration[] AllConfigurations { get; }
        DeviceDataConfiguration LPH2Configuration { get; }
        ICommand SaveConfiguration { get; }
    }
}