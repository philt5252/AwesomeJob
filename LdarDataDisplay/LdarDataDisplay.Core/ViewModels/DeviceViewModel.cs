using System;
using LdarDataDisplay.Foundation.Models;
using LdarDataDisplay.Foundation.ViewModels;

namespace LdarDataDisplay.Core.ViewModels
{
    public class DeviceViewModel : ViewModel, IDeviceViewModel
    {
        private ILdarDeviceData deviceData;

        public string Id
        {
            get { return deviceData.Id; }
        }

        public DateTime TimeSinceLastUpdate
        {
            get { return deviceData.TimeSinceLastUpdate; }
        }

        public double LPH2
        {
            get { return deviceData.LPH2; }
        }

        public double DetectorTemp
        {
            get { return deviceData.DetectorTemp; }
        }

        public double Voltage
        {
            get { return deviceData.Voltage; }
        }

        public double H2Pressure
        {
            get { return deviceData.H2Pressure; }
        }

        public double PPM
        {
            get { return deviceData.PPM; }
        }

        public double PumpPPL
        {
            get { return deviceData.PumpPPL; }
        }

        public DateTime CalibrationAge
        {
            get { return deviceData.CalibrationAge; }
        }

        public DateTime LastDrift
        {
            get { return deviceData.LastDrift; }
        }

        public bool IsFlameout
        {
            get { return deviceData.IsFlameout; }
        }

        public DeviceViewModel(ILdarDeviceData deviceData)
        {
            this.deviceData = deviceData;
        }
    }
}