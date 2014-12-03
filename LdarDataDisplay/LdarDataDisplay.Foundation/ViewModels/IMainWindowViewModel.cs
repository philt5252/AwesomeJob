using System.ComponentModel;
using System.Windows.Input;

namespace LdarDataDisplay.Foundation.ViewModels
{
    public interface IMainWindowViewModel : INotifyPropertyChanged
    {
         ICommand ShowScreenLayoutCommand { get; }
    }
}