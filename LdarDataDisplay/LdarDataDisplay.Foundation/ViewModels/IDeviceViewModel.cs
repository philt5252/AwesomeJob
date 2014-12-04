using System;
using System.ComponentModel;

namespace LdarDataDisplay.Foundation.ViewModels
{
    public interface IDeviceViewModel : INotifyPropertyChanged
    {
         string Id { get; }
         DateTime TimeSinceLastUpdate { get;  }
         double LPH2 { get; }
         double DetectorTemp { get; }
         double Voltage { get;  }
         double H2Pressure { get; }
         double PPM { get; }
         double PumpPPL { get; }
         DateTime CalibrationAge { get; }
         DateTime LastDrift { get; }

         bool IsFlameout { get; }
    }
}