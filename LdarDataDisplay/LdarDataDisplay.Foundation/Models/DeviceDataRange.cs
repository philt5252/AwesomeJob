using System.Windows.Media;

namespace LdarDataDisplay.Foundation.Models
{
    public class DeviceDataRange
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public Color Color { get; set; }

        public bool IsInRange(double value)
        {
            return Min <= value && value <= Max;
        }
    }
}