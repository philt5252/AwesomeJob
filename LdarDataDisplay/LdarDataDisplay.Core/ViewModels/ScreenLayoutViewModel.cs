using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using LdarDataDisplay.Core.Models;
using LdarDataDisplay.Foundation.Controllers;
using LdarDataDisplay.Foundation.DataAccess;
using LdarDataDisplay.Foundation.Models;
using LdarDataDisplay.Foundation.ViewModels;
using Microsoft.Practices.Prism.Commands;

namespace LdarDataDisplay.Core.ViewModels
{
    public class ScreenLayoutViewModel : ViewModel, IScreenLayoutViewModel
    {
        private readonly Dictionary<string, DeviceDataConfiguration> configs;
        private readonly IAppController appController;

        public DeviceDataConfiguration[] AllConfigurations{get { return configs.Values.ToArray(); }}
        public DeviceDataConfiguration LPH2Configuration { get { return configs["LPH2"]; } }
        public DeviceDataConfiguration DetectorTempConfiguration { get { return configs["DetectorTemp"]; } }
        public DeviceDataConfiguration VoltageConfiguration { get { return configs["Voltage"]; } }
        public DeviceDataConfiguration H2PressureConfiguration { get { return configs["H2Pressure"]; } }
        public DeviceDataConfiguration PPMConfiguration { get { return configs["PPM"]; } }
        public DeviceDataConfiguration PumpPPLConfiguration { get { return configs["PumpPPL"]; } }

        public ICommand SaveConfigurationCommand { get; protected set; }

        public ScreenLayoutViewModel(Dictionary<string, DeviceDataConfiguration> configs,
            IAppController appController)
        {
            this.configs = configs;
            this.appController = appController;

            SaveConfigurationCommand = new DelegateCommand(ExecuteSaveConfiguration);
        }

        private void ExecuteSaveConfiguration()
        {
            appController.SaveAndCloseConfiguration();
        }
    }
}