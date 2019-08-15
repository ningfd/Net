using Quartz.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VesNing.QuartZ
{
    class ConosleLogProvider : ILogProvider
    {
        public Logger GetLogger(string name)
        {
            return new Logger((logLevel, messageFunc, exception, formatParameters) =>
            {
                if (logLevel >= LogLevel.Info && messageFunc != null)
                {
                    Console.WriteLine($"[{ DateTime.Now.ToLongTimeString()}] [{ logLevel}] { messageFunc()} {string.Join(";", formatParameters.Select(p => p == null ? " " : p.ToString()))}  自定义日志{name}");
                }
                return true;
            });
        }

        public IDisposable OpenMappedContext(string key, string value)
        {
            throw new NotImplementedException();
        }

        public IDisposable OpenNestedContext(string message)
        {
            throw new NotImplementedException();
        }
    }
}
