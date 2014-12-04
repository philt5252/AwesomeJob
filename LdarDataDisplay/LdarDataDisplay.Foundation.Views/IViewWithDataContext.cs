using System;

namespace LdarDataDisplay.Foundation.Views
{
    public interface IViewWithDataContext
    {
        object DataContext { get; set; }
    }
}