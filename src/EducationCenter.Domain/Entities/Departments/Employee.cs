using EducationCenter.Domain.Commons;
using System.Collections.Generic;

namespace EducationCenter.Domain.Entities.Departments
{
    public class Employee : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Position { get; set; }

        public virtual ICollection<EmployeeSalary> EmployeeSalaries { get; set; }

    }
}
