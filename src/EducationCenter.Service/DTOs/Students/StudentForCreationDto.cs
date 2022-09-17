using System.ComponentModel.DataAnnotations;

namespace TestEducationCenterUoW.Service.DTOs.Students
{
    public class StudentForCreationDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public long CourseId { get; set; }
    }
}
