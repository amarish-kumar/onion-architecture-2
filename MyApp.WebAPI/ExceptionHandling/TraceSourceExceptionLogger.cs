using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

using MyApp.ServiceContracts;
using MyApp.Model;

namespace MyApp.WebAPI.ExceptionHandling
{
    public class TraceSourceExceptionLogger : ExceptionLogger
    {
        private readonly ILoggingService _logger;

        public TraceSourceExceptionLogger(ILoggingService logger)
        {
            _logger = logger;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            var logEntry = new LogEntry() 
            { 
                Title = "Global Error",
                Message = string.Format("Unhandled exception processing {0} for {1}", context.Request.Method, context.Request.RequestUri), 
                Categories = new string[] { "Global", "Main" }, 
                Severity = TraceEventType.Error,
                Source = this.GetType()
            };

            _logger.Write(logEntry, context.Exception);
        }
    }


}