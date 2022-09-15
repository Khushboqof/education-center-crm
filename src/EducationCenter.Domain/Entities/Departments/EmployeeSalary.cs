using EducationCenter.Domain.Commons;
using EducationCenter.Domain.Enums;
using System;

namespace EducationCenter.Domain.Entities.Departments
{
    public class EmployeeSalary : Auditable
    {
        public long? EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public ItemState State { get; set; }
    }
}
