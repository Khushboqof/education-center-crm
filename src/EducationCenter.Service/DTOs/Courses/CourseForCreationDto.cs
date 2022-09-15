using System.ComponentModel.DataAnnotations;

namespace EducationCenter.Service.DTOs.Courses
{
    public class CourseForCreationDto
    {
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ushort Duration { get; set; }
        public string CourseForId { get; set; }
        public string CourseType { get; set; }
        public string CourseAuthor { get; set; }
        public string CourseDescription { get; set; }
        public int Star { get; set; }

    }
}
