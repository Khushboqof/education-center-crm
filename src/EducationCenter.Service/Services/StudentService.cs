using EducationCenter.Domain.Entities.Students;
using Mapster;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestEducationCenterUoW.Data.IRepositories;
using TestEducationCenterUoW.Data.Repositories;
using TestEducationCenterUoW.Service.DTOs.Students;
using TestEducationCenterUoW.Service.Interfaces;
namespace TestEducationCenterUoW.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService()
        {
            this.studentRepository = new StudentRepository();
        }

        public async Task<Student> CreateAsync(StudentForCreationDto studentDto)
        {
            var result = await studentRepository.CreateAsync(studentDto.Adapt<Student>());
            await studentRepository.SaveAsync();
            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Student, bool>> expression)
        {
            var isDeleted = await studentRepository.DeleteAsync(expression);
            await studentRepository.SaveAsync();
            return isDeleted;
        }

        public async Task<IEnumerable<Student>> GetAllAsync(Expression<Func<Student, bool>> expression = null)
            => await studentRepository.GetAllAsync(expression);

        public async Task<Student> GetAsync(Expression<Func<Student, bool>> expression)
        {
            var student = await studentRepository.GetAsync(expression);
            return student;
        }

        public async Task<Student> UpdateAsync(long id, StudentForCreationDto studentDto)
        {
            var student = await studentRepository.GetAsync(p => p.Id == id);

            student = await studentRepository.UpdateAsync(studentDto.Adapt(student));

            await studentRepository.SaveAsync();
            return student;
        }
    }
}
