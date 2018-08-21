using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.WebApi.Azure.DataAccess
{
    public interface IEmployeeDataService
    {
        IEnumerable<Models.Employee> GetEmployees();

        Models.Employee GetEmployeeById(int id);

        void AddNewEmployee(Models.Employee employee);

        void DeleteEmployeeById(int id);
    }
}
