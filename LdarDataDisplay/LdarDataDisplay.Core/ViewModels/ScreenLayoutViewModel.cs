﻿using System;
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