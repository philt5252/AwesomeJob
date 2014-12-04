using System;

namespace LdarDataDisplay.Foundation.Models
{
    public interface ILdarDeviceData
    {
        int Id { get; set; }
        DateTime TimeSinceLastUpdate { get; set; }
        double LPH2 { get; set; }
        double DetectorTemp { get; set; }
        double Voltage { get; set; }
        double H2Pressure { get; set; }
        double PPM { get; set; }
        double PumpPPL { get; set; }
        DateTime CalibrationAge { get; set; }
        DateTime LastDrift { get; set; }

        bool IsFlameout { get; set; }
    }
}