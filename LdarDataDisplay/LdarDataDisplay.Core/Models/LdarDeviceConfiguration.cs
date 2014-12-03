using System.Collections.Generic;
using System.Windows.Media;
using LdarDataDisplay.Foundation.Models;

namespace LdarDataDisplay.Core.Models
{
    public class LdarDeviceConfiguration : ILdarDeviceConfiguration
    {
        public int Id { get; set; }
        public Color Color { get; set; }
        public List<DeviceDataRange> Range { get; set; }
    }
}