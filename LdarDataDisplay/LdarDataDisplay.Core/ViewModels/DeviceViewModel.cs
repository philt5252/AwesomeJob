using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using LdarDataDisplay.Foundation.Models;
using LdarDataDisplay.Foundation.ViewModels;

namespace LdarDataDisplay.Core.ViewModels
{
    public class DeviceViewModel : ViewModel, IDeviceViewModel
    {
        private ILdarDeviceData deviceData;
        private readonly Dictionary<string, DeviceDataConfiguration> configs;

        public string Id
        {
            get { return deviceData.Id; }
        }

        public string TimeSinceLastUpdate
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(deviceData.TimeSinceLastUpdate.ToShortDateString());
                builder.Append(deviceData.TimeSinceLastUpdate.ToShortTimeString());
                return builder.ToString();
            }
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

        public string CalibrationAge
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(deviceData.CalibrationAge.ToShortDateString());
                builder.Append(deviceData.CalibrationAge.ToShortTimeString());
                return builder.ToString();
            }
        }

        public string LastDrift
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(deviceData.LastDrift.ToShortDateString());
                builder.Append(deviceData.LastDrift.ToShortTimeString());
                return builder.ToString();
            }
        }

        public bool IsFlameout
        {
            get { return deviceData.IsFlameout; }
        }

        public Color LPH2Color
        {
            get { return configs["LPH2"].GetColor(LPH2); }
        }

        public Color DetectorTempColor
        {
            get { return configs["DetectorTemp"].GetColor(DetectorTemp); }
        }

        public Color VoltageColor
        {
            get { return configs["Voltage"].GetColor(Voltage); }
        }

        public Color H2PressureColor
        {
            get { return configs["H2Pressure"].GetColor(H2Pressure); }
        }

        public Color PPMColor
        {
            get { return configs["PPM"].GetColor(PPM); }
        }

        public Color PumpPPLColor
        {
            get { return configs["PumpPPL"].GetColor(PumpPPL); }
        }

        public DeviceViewModel(ILdarDeviceData deviceData, Dictionary<string, DeviceDataConfiguration> configs )
        {
            this.deviceData = deviceData;
            this.configs = configs;
        }
    }
}