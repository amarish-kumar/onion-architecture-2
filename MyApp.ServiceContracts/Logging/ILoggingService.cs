using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyApp.Model;

namespace MyApp.ServiceContracts
{
    public interface ILoggingService
    {
        void Write(LogEntry entry, Exception ex = null);
    }
}
