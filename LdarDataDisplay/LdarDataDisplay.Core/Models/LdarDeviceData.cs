using System;
using LdarDataDisplay.Foundation.Models;

namespace LdarDataDisplay.Core.Models
{
    public class LdarDeviceData : ILdarDeviceData
    {
        public int Id { get; set; }
        public DateTime TimeSinceLastUpdate { get; set; }
        public double LPH2 { get; set; }
        public double DetectorTemp { get; set; }
        public double Voltage { get; set; }
        public double H2Pressure { get; set; }
        public double PPM { get; set; }
        public double PumpPPL { get; set; }
        public DateTime CalibrationAge { get; set; }
        public DateTime LastDrift { get; set; }
        public bool IsFlameout { get; set; }
    }
}