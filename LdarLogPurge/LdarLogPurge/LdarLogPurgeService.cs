using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;

namespace LdarLogPurge
{
    public partial class LdarLogPurgeService : ServiceBase
    {
        public LdarLogPurgeService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var dirsToDelete = Directory.EnumerateDirectories(@"C\Logs")
                .Where(d =>
                {
                    DateTime dateTimeNow = DateTime.Now;
                    DateTime folderDateTime = DateTime.Parse(new DirectoryInfo(d).Name);

                    if (dateTimeNow.Month - folderDateTime.Month > 6)
                        return true;

                    if (dateTimeNow.Month - folderDateTime.Month == 6
                        && dateTimeNow.Day > folderDateTime.Day)
                        return true;

                    return false;
                });

            foreach (var dir in dirsToDelete)
            {
                Directory.Delete(dir);
            }

        }

        protected override void OnStop()
        {
        }
    }
}
