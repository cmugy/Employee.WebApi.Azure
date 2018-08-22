using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.WebApi.Azure.DataAccess
{
    public class EmployeeDataService : IEmployeeDataService
    {
        public IEnumerable<Models.Employee> GetEmployees()
        {
            var connectionString = ConfigurationManager.AppSettings.Get("connectionString");

            var employees= new List<Models.Employee>();

            try
            {

                using (var connection = new SqlConnection(connectionString))
                {

                    //todo use stored procedure SQL inject??
                    var command = new SqlCommand("select * from Employee", connection);

                    connection.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var employee = new Models.Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Salary = (decimal) reader.GetDouble(3),
                            StartDate = reader.GetDateTime(4)
                        };

                        employees.Add(employee);
                    }


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            //return new List<Models.Employee>
            //{
            //    new Models.Employee
            //    {
            //        Id = 1,
            //        FirstName = "Collins",
            //        LastName = "Mugarura",
            //        Salary = 43000,
            //        StartDate = new DateTime(2017, 11,09)
            //    }
            //};
            return employees;

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
