using System;
using System.Runtime.Serialization;
using System.Windows.Media;

namespace LdarDataDisplay.Foundation.Models
{
    [Serializable]
    public class DeviceDataRange
    {
        [NonSerialized]
        private Color color;

        public double Min { get; set; }
        public double Max { get; set; }

        [IgnoreDataMember]
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                ColorNumber = color.ToString();
            }
        }

        public string ColorNumber { get; set; }

        public bool IsInRange(double value)
        {
            return Min <= value && value <= Max;
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            Color = (Color)ColorConverter.ConvertFromString(ColorNumber);
        }
    }
}