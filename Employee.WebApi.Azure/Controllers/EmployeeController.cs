using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Employee.WebApi.Azure.DataAccess;
using Employee = Employee.WebApi.Azure.Models.Employee;

namespace Employee.WebApi.Azure.Controllers
{
    public class EmployeeController : ControllerBase
    {
        private IEmployeeDataService _employeeDataService = new EmployeeDataService(); // todo use container

        public EmployeeController(IEmployeeDataService employeeDataService)
        {
            _employeeDataService = employeeDataService;
        }
         
        [HttpGet, Route("api/employees")]
        public IEnumerable<Models.Employee> GetAllEmployees()
        {
            return new List<Models.Employee>
            {
                new Models.Employee
                {
                    Id = 1,
                    FirstName = "Collins",
                    LastName = "Mugarura",
                    Salary = 43000,
                    StartDate = new DateTime(2017, 11,09)
                }
            };
        }
    }
}
