using EducationCenter.Domain.Commons;

namespace EducationCenter.Domain.Entities.Courses
{
    public class Course : Auditable
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ushort Duration { get; set; }
        public string CourseDescription { get; set; }
    }
}
