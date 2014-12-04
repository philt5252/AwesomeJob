using System.Windows.Media;

namespace LdarDataDisplay.Foundation.Models
{
    public class DeviceData
    {
        private readonly DeviceDataConfiguration deviceDataConfiguration;
        public double Value { get; set; }

        public Color Color
        {
            get
            {
                return deviceDataConfiguration.GetColor(Value);
            }
        }

        public DeviceData(DeviceDataConfiguration deviceDataConfiguration)
        {
            this.deviceDataConfiguration = deviceDataConfiguration;
        }
    }
}