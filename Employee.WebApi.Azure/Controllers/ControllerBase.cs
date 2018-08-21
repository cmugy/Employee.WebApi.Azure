using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Employee.WebApi.Azure.Services;
using log4net;

namespace Employee.WebApi.Azure.Controllers
{
    public class ControllerBase : ApiController
    {
        protected ILog log;
        private ILogProvider _logProvider;

        public ControllerBase(ILogProvider logProvider)
        {
            _logProvider = logProvider;
            log = _logProvider.GetLogger(GetType());
        }
    }
}