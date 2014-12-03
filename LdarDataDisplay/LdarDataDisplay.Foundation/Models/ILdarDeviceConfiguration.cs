using System.Collections.Generic;
using System.Windows.Media;

namespace LdarDataDisplay.Foundation.Models
{
    public interface ILdarDeviceConfiguration
    {
        int Id { get; set; }
        Color Color { get; set; }
        List<DeviceDataRange> Range { get; set; }
    }
}