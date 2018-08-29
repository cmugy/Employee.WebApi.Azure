using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

                    connection.Close();
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
            try
            {
                return GetEmployees().FirstOrDefault(p => p.Id == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public void AddNewEmployee(Models.Employee employee)
        {
            var connectionString = ConfigurationManager.AppSettings.Get("connectionString");
            var data = $"\'{employee.FirstName}\', \'{employee.LastName}\', \'{employee.Salary}\', \'{employee.StartDate:yyyy-MM-dd}\'";
            var query = "INSERT INTO Employee (FirstName, LastName, Salary, StartDate)" + "VALUES (" + data + ")";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand("insertNewemployee", connection)
                    {
                        CommandType = CommandType.StoredProcedure,
                        Parameters =
                        {
                            new SqlParameter("@firstName", employee.FirstName),
                            new SqlParameter("@lastName", employee.LastName),
                            new SqlParameter("@salary", employee.Salary),
                            new SqlParameter("@startDate", employee.StartDate)
                        }

                    };


                    connection.Open();

                    var i = command.ExecuteNonQuery();

                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
