using System.ComponentModel.DataAnnotations;

namespace EducationCenter.Service.DTOs.Teachers
{
    public class TeacherForCreationDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
