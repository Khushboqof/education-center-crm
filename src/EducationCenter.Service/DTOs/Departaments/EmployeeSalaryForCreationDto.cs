using EducationCenter.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EducationCenter.Service.DTOs.Departaments
{
    public class EmployeeSalaryForCreationDto
    {
        [Required]
        public long EmployeeId { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public PaymentType PaymentType { get; set; }
    }
}
