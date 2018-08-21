using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace Employee.WebApi.Azure.Services
{
    public interface ILogProvider
    {
        ILog GetLogger(Type type);
    }
}