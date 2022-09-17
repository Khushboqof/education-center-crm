using EducationCenter.Domain.Commons;

namespace EducationCenter.Domain.Entities.Students
{
    public class Student : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public long? CourseId { get; set; }
    }
}
