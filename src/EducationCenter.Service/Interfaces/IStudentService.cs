using EducationCenter.Domain.Entities.Students;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestEducationCenterUoW.Service.DTOs.Students;

namespace TestEducationCenterUoW.Service.Interfaces
{
    public interface IStudentService
    {
        Task<Student> CreateAsync(StudentForCreationDto studentDto);
        Task<Student> GetAsync(Expression<Func<Student, bool>> expression);
        Task<IEnumerable<Student>> GetAllAsync(Expression<Func<Student, bool>> expression = null);
        Task<bool> DeleteAsync(Expression<Func<Student, bool>> expression);
        Task<Student> UpdateAsync(long id, StudentForCreationDto studentDto);
    }
}
