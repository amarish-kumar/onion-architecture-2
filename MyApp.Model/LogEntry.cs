using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    public class LogEntry
    {
        public string Title { get; set; } 
        public string Message { get; set; } 
        public TraceEventType Severity { get; set; } 
        public string[] Categories { get; set; }
        public Type Source { get; set; }
    }
}
