using EducationCenter.Domain.Commons;
using EducationCenter.Domain.Enums;
using System;

namespace EducationCenter.Domain.Entities.Students
{
    public class Student : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public long? GroupId { get; set; }
    }
}
