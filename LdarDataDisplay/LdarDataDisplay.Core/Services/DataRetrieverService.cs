using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using LdarDataDisplay.Foundation.DataAccess;
using LdarDataDisplay.Foundation.Models;
using LdarDataDisplay.Foundation.Services;

namespace LdarDataDisplay.Core.Services
{
    public class DataRetrieverService : IDataRetrieverService
    {
        private readonly ILdarDeviceRepository repository;
        public event EventHandler<DataRetrievedEventArgs> DataRetrieved;
        private string logsFolder = StaticData.LogsFolder;
        private readonly FileSystemWatcher fileWatcher;
        private DateTime lastChange = DateTime.Today - TimeSpan.FromDays(1);
        private TimeSpan threshold = TimeSpan.FromSeconds(30);
        private TimeSpan waitTime = TimeSpan.FromSeconds(1);

        public DataRetrieverService(ILdarDeviceRepository repository)
        {
            this.repository = repository;

            fileWatcher = new FileSystemWatcher(logsFolder);
            fileWatcher.Changed += FileWatcherOnChanged;
        }

        private void FileWatcherOnChanged(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            if (DateTime.Now - lastChange < threshold)
                return;

            lastChange = DateTime.Now;

            Task retrieveDataAndRaiseEventTask = new Task(
                () =>
                {
                    Thread.Sleep(waitTime);
                    RetrieveDataAndRaiseEvent();
                });

            retrieveDataAndRaiseEventTask.Start();
        }

        protected void RetrieveDataAndRaiseEvent()
        {
            DateTime dateTime = DateTime.Now;

            string folder = Path.Combine(logsFolder, dateTime.ToString("yyyy-MM-dd"));

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            foreach (string filePath in Directory.EnumerateFiles(logsFolder))
            {
                FileInfo file = new FileInfo(filePath);

                File.Copy(filePath, Path.Combine(folder, file.Name));
            }

            ILdarDeviceData[] ldarDeviceDatas = repository.RetrieveData();

            OnDataRetrieved(new DataRetrievedEventArgs(ldarDeviceDatas));
        }

        protected virtual void OnDataRetrieved(DataRetrievedEventArgs e)
        {
            EventHandler<DataRetrievedEventArgs> handler = DataRetrieved;
            if (handler != null) handler(this, e);
        }

        public void Start()
        {
            fileWatcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            fileWatcher.EnableRaisingEvents = false;
        }
    }
}