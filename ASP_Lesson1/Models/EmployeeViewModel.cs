using ASP_Lesson1.Entities;
using System.Collections.Generic;

namespace ASP_Lesson1.Models
{
    public class EmployeeViewModel
    {
        public List<Employee> Employees { get; set; }
        public List<string> Cities { get; set; }
    }
}
