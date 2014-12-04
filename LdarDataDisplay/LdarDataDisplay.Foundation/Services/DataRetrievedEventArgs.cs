using System;
using LdarDataDisplay.Foundation.Models;

namespace LdarDataDisplay.Foundation.Services
{
    public class DataRetrievedEventArgs : EventArgs
    {
        public ILdarDeviceData[] Data { get; set; }

        public DataRetrievedEventArgs(ILdarDeviceData[] data)
        {
            Data = data;
        }
    }
}