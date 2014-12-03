using System;

namespace LdarDataDisplay.Foundation.Models
{
    public interface ILdarDeviceData
    {
        int Id { get; set; }
        TimeSpan TimeSinceLastUpdate { get; set; }
        double Lph2 { get; set; }
        double DetectorTemp { get; set; }
        double Voltage { get; set; }
        double H2Pressure { get; set; }
        double PPM { get; set; }
        double PumpPPL { get; set; }
        double CalibrationAge { get; set; }
        double LastDrift { get; set; }

        bool IsFlameout { get; set; }
    }
}