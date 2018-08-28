using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Employee.WebApi.Azure.DataAccess;
using Employee.WebApi.Azure.Services;
//using Employee = Employee.WebApi.Azure.Models.Employee;

namespace Employee.WebApi.Azure.Controllers
{
    [EnableCors(headers:"*",origins:"*", methods:"*")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDataService _employeeDataService;

                
        [HttpGet, Route("api/employees")]
        public IEnumerable<Models.Employee> GetAllEmployees()
        {
            var employees = _employeeDataService.GetEmployees();

            return employees;
        }

        public EmployeeController(ILogProvider logProvider, IEmployeeDataService employeeDataService) : base(logProvider)
        {
            _employeeDataService = employeeDataService;
        }

        [HttpGet, Route("api/employees/{id}")]
        public Models.Employee GetEmployeeById(int id)
        {
            log.InfoFormat("Received request to get employee {0}", id);

            return _employeeDataService.GetEmployeeById(id);
        }
    }
}
