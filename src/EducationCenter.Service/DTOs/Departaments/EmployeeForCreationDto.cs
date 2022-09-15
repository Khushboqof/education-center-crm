using System.ComponentModel.DataAnnotations;

namespace EducationCenter.Service.DTOs.Departaments
{
    public class EmployeeForCreationDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Position { get; set; }
    }
}
