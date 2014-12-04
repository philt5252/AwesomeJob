using System;

namespace LdarDataDisplay.Foundation.Services
{
    public interface IDataRetrieverService
    {
        event EventHandler<DataRetrievedEventArgs> DataRetrieved;
        void Start();
        void Stop();
    }
}