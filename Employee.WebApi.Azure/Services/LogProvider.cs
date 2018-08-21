using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace Employee.WebApi.Azure.Services
{
    public class LogProvider : ILogProvider
    {
        public ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }
    }
}