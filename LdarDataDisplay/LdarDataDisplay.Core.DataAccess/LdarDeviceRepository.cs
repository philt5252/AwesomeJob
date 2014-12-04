using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LdarDataDisplay.Core.Models;
using LdarDataDisplay.Foundation.DataAccess;
using LdarDataDisplay.Foundation.Models;

namespace LdarDataDisplay.Core.DataAccess
{
    public class LdarDeviceRepository : ILdarDeviceRepository
    {
        public ILdarDeviceData[] RetrieveData()
        {
            List<ILdarDeviceData> data = new List<ILdarDeviceData>();

            string currentDataDirectory = Directory.EnumerateDirectories(StaticData.LogsFolder).OrderByDescending(DateTime.Parse).First();

            foreach (string filepath in Directory.EnumerateFiles(currentDataDirectory))
            {
                
            }

            for (int i = 1; i <= 6; i++)
            {
                ILdarDeviceData newData = new LdarDeviceData();

                newData.CalibrationAge = i;
                newData.DetectorTemp = i*100;
                newData.H2Pressure = i + 5;
                newData.Id = i;
                newData.IsFlameout = false;
                newData.LastDrift = i*1000 + 5;
                newData.Lph2 = i*100 + i*10;
                newData.PPM = i*100 + i*10 + i;

                data.Add(newData);
            }

            return data.ToArray();
        }
    }
}