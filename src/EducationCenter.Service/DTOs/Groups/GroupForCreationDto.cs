using System;
using System.ComponentModel.DataAnnotations;

namespace EducationCenter.Service.DTOs.Groups
{
    public class GroupForCreationDto
    {
        [Required]
        public long? TeacherId { get; set; }

        [Required]
        public long? CourseId { get; set; }

    }
}
