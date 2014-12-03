using System;
using LdarDataDisplay.Foundation.Models;

namespace LdarDataDisplay.Core.Models
{
    public class LdarDeviceData : ILdarDeviceData
    {
        public int Id { get; set; }
        public TimeSpan TimeSinceLastUpdate { get; set; }
        public double Lph2 { get; set; }
        public double DetectorTemp { get; set; }
        public double Voltage { get; set; }
        public double H2Pressure { get; set; }
        public double PPM { get; set; }
        public double PumpPPL { get; set; }
        public double CalibrationAge { get; set; }
        public double LastDrift { get; set; }
        public bool IsFlameout { get; set; }
    }
}