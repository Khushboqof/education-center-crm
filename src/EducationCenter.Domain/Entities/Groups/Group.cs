using EducationCenter.Domain.Commons;
using EducationCenter.Domain.Entities.Courses;
using EducationCenter.Domain.Entities.Students;
using EducationCenter.Domain.Entities.Teachers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EducationCenter.Domain.Entities.Groups
{
    public class Group : Auditable
    {
        [NotMapped]
        public string Name { get; set; }

        public long? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public long? CourseId { get; set; }
        public Course Course { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
