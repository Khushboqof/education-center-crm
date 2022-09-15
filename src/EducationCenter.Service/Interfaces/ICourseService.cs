using EducationCenter.Domain.Entities.Courses;
using EducationCenter.Service.DTOs.Courses;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationCenter.Service.Interfaces
{
    public interface ICourseService
    {
        Task<Course> CreateAsync(CourseForCreationDto courseDto);
        Task<Course> GetAsync(Expression<Func<Course, bool>> expression);
        Task<IEnumerable<Course>> GetAllAsync(Expression<Func<Course, bool>> expression = null);
        Task<bool> DeleteAsync(Expression<Func<Course, bool>> expression);
        Task<Course> UpdateAsync(long id, CourseForCreationDto courseDto);
    }
}
