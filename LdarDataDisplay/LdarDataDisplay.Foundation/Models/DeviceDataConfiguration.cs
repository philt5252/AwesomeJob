using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace LdarDataDisplay.Foundation.Models
{
    [Serializable]
    public class DeviceDataConfiguration
    {
        public string DataName { get; set; }
        public List<DeviceDataRange> DeviceDataRanges { get; protected set; }

        public DeviceDataConfiguration()
        {
            DeviceDataRanges = new List<DeviceDataRange>()
            {
                new DeviceDataRange {Color = Color.FromRgb(0, 255, 0)},
                new DeviceDataRange {Color = Color.FromRgb(255, 255, 0)},
                new DeviceDataRange {Color = Color.FromRgb(255, 0, 0)}
            };
        }

        public Color GetColor(double value)
        {
            foreach (DeviceDataRange deviceDataRange in DeviceDataRanges)
            {
                if (deviceDataRange.IsInRange(value))
                    return deviceDataRange.Color;
            }

            return Color.FromRgb(0, 0, 0);
        }
    }
}