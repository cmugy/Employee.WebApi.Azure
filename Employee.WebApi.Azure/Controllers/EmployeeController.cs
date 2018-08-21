using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Employee.WebApi.Azure.DataAccess;
using Employee.WebApi.Azure.Services;
using Employee = Employee.WebApi.Azure.Models.Employee;

namespace Employee.WebApi.Azure.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private IEmployeeDataService _employeeDataService = new EmployeeDataService(); // todo use container

        
         
        [HttpGet, Route("api/employees")]
        public IEnumerable<Models.Employee> GetAllEmployees()
        {
            var employees = _employeeDataService.GetEmployees();

            return employees;
        }

        public EmployeeController(ILogProvider logProvider) : base(logProvider)
        {
        }
    }
}
