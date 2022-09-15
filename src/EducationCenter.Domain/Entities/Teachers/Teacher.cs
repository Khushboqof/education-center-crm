using EducationCenter.Domain.Commons;
using EducationCenter.Domain.Entities.Courses;
using EducationCenter.Domain.Enums;
using System;
using System.Collections.Generic;

namespace EducationCenter.Domain.Entities.Teachers
{
    public class Teacher : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}
