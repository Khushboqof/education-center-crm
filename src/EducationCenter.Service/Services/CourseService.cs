using EducationCenter.Data.IRepositories;
using EducationCenter.Domain.Entities.Courses;
using EducationCenter.Domain.Enums;
using EducationCenter.Service.DTOs.Courses;
using EducationCenter.Service.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationCenter.Service.Services
{
    public class CourseService : ICourseService
    {

        private readonly ICourseRepository courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }


        public async Task<Course> CreateAsync(CourseForCreationDto courseDto)
        {
            var result = await courseRepository.CreateAsync(courseDto.Adapt<Course>());

            await courseRepository.SaveAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Course, bool>> expression)
        {
            var isDeleted = await courseRepository.DeleteAsync(expression);
            await courseRepository.SaveAsync();
            return isDeleted;
        }

        public async Task<IEnumerable<Course>> GetAllAsync(Expression<Func<Course, bool>> expression = null)
            => await courseRepository.GetAllAsync(expression => expression.State != ItemState.Deleted);

        public async Task<Course> GetAsync(Expression<Func<Course, bool>> expression)
        {
            var courses = await courseRepository.GetAsync(expression);
            return courses is null ? null : courses;
        }

        public async Task<Course> UpdateAsync(long id, CourseForCreationDto courseDto)
        {

            var course = await courseRepository.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);

            var result = await courseRepository.UpdateAsync(courseDto.Adapt(course));

            await courseRepository.SaveAsync();

            return result;
        }
    }
}
