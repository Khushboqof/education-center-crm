using EducationCenter.Domain.Enums;
using System;

namespace EducationCenter.Domain.Commons
{
    public class Auditable
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long? UpdatedBy { get; set; }
        public ItemState State { get; set; }
    }
}
