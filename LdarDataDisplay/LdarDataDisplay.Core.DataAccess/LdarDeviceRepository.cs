using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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
                ILdarDeviceData ldarDeviceData = ldarDeviceDataFactory.Create();
                data.Add(ldarDeviceData);

                string[] dataLines = File.ReadAllLines(filepath);
                int numConsecutiveZeros = 0;

                bool foundCalibrationAge = false;
                bool foundLastDrift = false;

                string[] currentDataEntries = dataLines[dataLines.Length-1].Split(',');

                ldarDeviceData.TimeSinceLastUpdate =
                        DateTime.Parse(currentDataEntries[Index('A')] + " " + currentDataEntries[Index('B')]);

                ldarDeviceData.LPH2 = double.Parse(currentDataEntries[Index('H')]);
                ldarDeviceData.DetectorTemp = double.Parse(currentDataEntries[Index('J')]);
                ldarDeviceData.Voltage = double.Parse(currentDataEntries[Index('M')]);
                ldarDeviceData.H2Pressure = double.Parse(currentDataEntries[Index('N')]);
                ldarDeviceData.PPM = double.Parse(currentDataEntries[Index('S')]);
                ldarDeviceData.PumpPPL = double.Parse(currentDataEntries[Index('T')]);
                ldarDeviceData.LPH2 = double.Parse(currentDataEntries[Index('H')]);
                ldarDeviceData.LastDrift = DateTime.MinValue;
                ldarDeviceData.CalibrationAge = DateTime.MinValue;

                for (int i = dataLines.Length-2; i >=0 || (!foundCalibrationAge || !foundLastDrift); i--)
                {
                    string[] dataEntries = dataLines[i].Split(',');

                    if (dataEntries.Length < 10)
                        continue;

                    double ppm = double.Parse(dataEntries[Index('S')]);

                    if (!foundCalibrationAge && ppm == 0.0)
                    {
                        numConsecutiveZeros++;

                        if (numConsecutiveZeros >= 5)
                        {
                            ldarDeviceData.CalibrationAge =
                                DateTime.Parse(dataEntries[Index('A')] + " " + dataEntries[Index('B')]);
                            
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

        private int Index(char col)
        {
            col = char.ToUpper(col);

            return col - 'A';
        }
    }
}