using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlickrSearch
{
    public sealed class Logger
    {
        public static void WriteLog(string message)
        {
            try
            {
                File.AppendAllText(Constants.LOG_FILE_NAME, DateTime.Now + " " + message + Environment.NewLine);
            }
            catch { }
        }
    }
}
