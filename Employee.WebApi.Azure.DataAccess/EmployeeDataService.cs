using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.WebApi.Azure.DataAccess
{
    public class EmployeeDataService : IEmployeeDataService
    {
        public IEnumerable<Models.Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Models.Employee GetEmployeeById(int id)
        {
            throw new NotImplementedException("Connect to Azure db here");
        }

        public void AddNewEmployee(Models.Employee employee)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
