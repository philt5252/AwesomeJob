using System;
using System.ComponentModel;
using System.Windows.Media;

namespace LdarDataDisplay.Foundation.ViewModels
{
    public interface IDeviceViewModel : INotifyPropertyChanged
    {
        string Id { get; }
        string TimeSinceLastUpdate { get; }
        double LPH2 { get; }
        double DetectorTemp { get; }
        double Voltage { get; }
        double H2Pressure { get; }
        double PPM { get; }
        double PumpPPL { get; }
        string CalibrationAge { get; }
        string LastDrift { get; }

        Color LPH2Color { get; }
        Color DetectorTempColor { get; }
        Color VoltageColor { get; }
        Color H2PressureColor { get; }
        Color PPMColor { get; }
        Color PumpPPLColor { get; }
    }
}