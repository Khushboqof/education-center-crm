using EducationCenter.Domain.Entities.Teachers;
using EducationCenter.Service.DTOs.Teachers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationCenter.Service.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher> CreateAsync(TeacherForCreationDto teachertDto);
        Task<Teacher> GetAsync(Expression<Func<Teacher, bool>> expression);
        Task<IEnumerable<Teacher>> GetAllAsync(Expression<Func<Teacher, bool>> expression = null);
        Task<bool> DeleteAsync(Expression<Func<Teacher, bool>> expression);
        Task<Teacher> UpdateAsync(long id, TeacherForCreationDto teachertDto);

    }
}
