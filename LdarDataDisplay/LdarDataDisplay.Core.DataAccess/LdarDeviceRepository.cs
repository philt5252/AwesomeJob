using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using LdarDataDisplay.Core.Models;
using LdarDataDisplay.Foundation.DataAccess;
using LdarDataDisplay.Foundation.Factories.Models;
using LdarDataDisplay.Foundation.Models;

namespace LdarDataDisplay.Core.DataAccess
{
    public class LdarDeviceRepository : ILdarDeviceRepository
    {
        private readonly ILdarDeviceDataFactory ldarDeviceDataFactory;

        public LdarDeviceRepository(ILdarDeviceDataFactory ldarDeviceDataFactory)
        {
            this.ldarDeviceDataFactory = ldarDeviceDataFactory;
        }

        public ILdarDeviceData[] RetrieveData()
        {
            List<ILdarDeviceData> data = new List<ILdarDeviceData>();

            string currentDataDirectory = Directory.EnumerateDirectories(StaticData.LogsFolder)
                .OrderByDescending(d => DateTime.Parse(new DirectoryInfo(d).Name)).FirstOrDefault();

            if(currentDataDirectory == null)
                return new ILdarDeviceData[0];

            foreach (string filepath in Directory.EnumerateFiles(currentDataDirectory))
            {
                FileInfo fileInfo = new FileInfo(filepath);

                Match match = Regex.Match(fileInfo.Name, @".*-(\d*)_.*");

                if (!match.Success)
                    continue;

                string id = match.Groups[1].Value;

                ILdarDeviceData ldarDeviceData = ldarDeviceDataFactory.Create();
                ldarDeviceData.Id = id;

                data.Add(ldarDeviceData);

                string[] dataLines = File.ReadAllLines(filepath);
                int numConsecutiveZeros = 0;

                DateTime calibrationAge = DateTime.MinValue;

                bool foundCalibrationAge = false;
                bool foundLastDrift = false;
                bool isCurrentDataSet = false;
                
                for (int i = dataLines.Length-1; i >=0 && (!foundCalibrationAge || !foundLastDrift); i--)
                {
                    string[] dataEntries = dataLines[i].Split(',');

                    if (dataEntries.Length < 10)
                        continue;

                    if (!isCurrentDataSet)
                    {
                        SetCurrentData(ldarDeviceData, dataEntries);

                        if (ldarDeviceData.IsFlameout)
                            break;

                        isCurrentDataSet = true;
                    }

                    double ppm = double.Parse(dataEntries[Index('S')]);

                    if (!foundCalibrationAge && ppm == 0.0)
                    {
                        if(numConsecutiveZeros == 0)
                            calibrationAge = DateTime.Parse(dataEntries[Index('A')] + " " + dataEntries[Index('B')]);

                        numConsecutiveZeros++;

                        if (numConsecutiveZeros >= 5)
                        {
                            ldarDeviceData.CalibrationAge = calibrationAge;
                            
                            foundCalibrationAge = true;
                        }

                        continue;
                    }
                    
                    numConsecutiveZeros = 0;

                    if (!foundLastDrift && ppm > 1000)
                    {
                        ldarDeviceData.LastDrift =
                            DateTime.Parse(dataEntries[Index('A')] + " " + dataEntries[Index('B')]);

                        foundLastDrift = true;
                    }
                }
            }

            return data.ToArray();
        }

        private void SetCurrentData(ILdarDeviceData ldarDeviceData, string[] dataEntries)
        {
            ldarDeviceData.TimeSinceLastUpdate =
                DateTime.Parse(dataEntries[Index('A')] + " " + dataEntries[Index('B')]);

            ldarDeviceData.LPH2 = double.Parse(dataEntries[Index('H')]);
            ldarDeviceData.DetectorTemp = double.Parse(dataEntries[Index('J')]);
            ldarDeviceData.Voltage = double.Parse(dataEntries[Index('M')]);
            ldarDeviceData.H2Pressure = double.Parse(dataEntries[Index('N')]);
            ldarDeviceData.PPM = double.Parse(dataEntries[Index('S')]);
            ldarDeviceData.PumpPPL = double.Parse(dataEntries[Index('T')]);
            ldarDeviceData.LPH2 = double.Parse(dataEntries[Index('H')]);
            ldarDeviceData.LastDrift = DateTime.MinValue;
            ldarDeviceData.CalibrationAge = DateTime.MinValue;

            double q;
            double r;

            ldarDeviceData.IsFlameout = 
            !double.TryParse(dataEntries[Index('Q')], out q) ||
                !double.TryParse(dataEntries[Index('R')], out r);

        }

        private int Index(char col)
        {
            col = char.ToUpper(col);

            return col - 'A';
        }
    }
}