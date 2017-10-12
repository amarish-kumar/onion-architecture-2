using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyApp.ServiceContracts;
using MyApp.Model;
using log4net.Core;
using System.Diagnostics;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace MyApp.Logging
{
    public class Logger : ILoggingService
    {
        private static readonly ILog log = LogManager.GetLogger("AppLogger");

        public void Write(LogEntry entry, Exception ex)
        {
            log.Logger.Log(entry.Source, GetLevel(entry.Severity), GetMessage(entry), ex);
        }

        private string  GetMessage(LogEntry entry)
        {
            string message = string.Empty;

            if(!string.IsNullOrEmpty(entry.Title))
            {
                message += "Title: " + entry.Title + "; ";
            }

            if(entry.Categories.Length > 0)
	        {
                message += "Category: " + string.Join(",", entry.Categories) + "; ";
            }

            message += "Message: " + entry.Message;

            return message;
        }

        private Level GetLevel(TraceEventType severity)
        {
            Level level;

            switch (severity)
            {
                case TraceEventType.Critical:
                    level = Level.Critical;
                    break;
                case TraceEventType.Error:
                    level = Level.Error;
                    break;
                case TraceEventType.Information:
                    level = Level.Info;
                    break;
                case TraceEventType.Verbose:
                    level = Level.Verbose;
                    break;
                case TraceEventType.Warning:
                    level = Level.Warn;
                    break;
                default:
                    level = Level.Info;
                    break;
            }

            return level;
        }
    }
}
