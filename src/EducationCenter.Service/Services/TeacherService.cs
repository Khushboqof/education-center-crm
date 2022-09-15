using EducationCenter.Data.IRepositories;
using EducationCenter.Data.Repositories;
using EducationCenter.Domain.Entities.Teachers;
using EducationCenter.Service.DTOs.Teachers;
using EducationCenter.Service.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationCenter.Service.Services
{
    public class TeacherService : ITeacherService
    {


        private readonly ITeacherRepository teacherRepository;

        public TeacherService()
        {
            this.teacherRepository = new TeacherRepository();
        }


        public async Task<Teacher> CreateAsync(TeacherForCreationDto teachertDto)
        {
            var result = await teacherRepository.CreateAsync(teachertDto.Adapt<Teacher>());

            await teacherRepository.SaveAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Teacher, bool>> expression)
        {
            var isDeleted = await teacherRepository.DeleteAsync(expression);
            await teacherRepository.SaveAsync();
            return isDeleted;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync(Expression<Func<Teacher, bool>> expression = null)
            => await teacherRepository.GetAllAsync(expression);

        public async Task<Teacher> GetAsync(Expression<Func<Teacher, bool>> expression)
            => await teacherRepository.GetAsync(expression);

        public async Task<Teacher> UpdateAsync(long id, TeacherForCreationDto teacherDto)
        {
            var teacher = await teacherRepository.GetAsync(p => p.Id == id);

            var result = await teacherRepository.UpdateAsync(teacherDto.Adapt(teacher));

            await teacherRepository.SaveAsync();
            return result;
        }
    }
}