using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Employee.WebApi.Azure.Models
{
    [DataContract(Namespace = "")]
    public class Employee
    {
        [DataMember(Name = "id")] public int Id { get; set; }

        [DataMember(Name = "firstName")] public string FirstName { get; set; }

        [DataMember(Name = "lastName")] public string LastName { get; set; }

        [DataMember (Name = "salary")] public decimal Salary { get; set; }

        [DataMember (Name = "startDate")] public DateTime StartDate { get; set; }
    }
}