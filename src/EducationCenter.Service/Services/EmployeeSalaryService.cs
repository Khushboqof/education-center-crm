using EducationCenter.Data.Repositories;
using EducationCenter.Domain.Entities.Departments;
using EducationCenter.Service.DTOs.Departaments;
using EducationCenter.Service.Interfaces;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationCenter.Service.Services
{
    public class EmployeeSalaryService : IEmployeeSalaryService
    {
        private readonly EmployeeSalaryRepository employeeSalaryRepository;

        public EmployeeSalaryService()
        {
            this.employeeSalaryRepository = new EmployeeSalaryRepository();
        }

        public async Task<EmployeeSalary> CreateAsync(EmployeeSalaryForCreationDto employeeSalaryDto)
        {
            var result = await employeeSalaryRepository.CreateAsync(employeeSalaryDto.Adapt<EmployeeSalary>());

            await employeeSalaryRepository.SaveAsync();

            return result;

        }

        public async Task<bool> DeleteAsync(Expression<Func<EmployeeSalary, bool>> expression)
        {
            var isDeleted = await employeeSalaryRepository.DeleteAsync(expression);
            await employeeSalaryRepository.SaveAsync();
            return isDeleted;
        }
        public async Task<IEnumerable<EmployeeSalary>> GetAllAsync(Expression<Func<EmployeeSalary, bool>> expression = null) =>
            await employeeSalaryRepository.GetAllAsync(expression);

        public async Task<EmployeeSalary> GetAsync(Expression<Func<EmployeeSalary, bool>> expression)
            => await employeeSalaryRepository.GetAsync(expression);

        public async Task<EmployeeSalary> UpdateAsync(long id, EmployeeSalaryForCreationDto employeeSalaryDto)
        {

            // check for exist employeeSalary
            var employeeSalary = await employeeSalaryRepository.GetAsync(p => p.Id == id);
            var result = await employeeSalaryRepository.UpdateAsync(employeeSalaryDto.Adapt(employeeSalary));
            await employeeSalaryRepository.SaveAsync();
            return result;
        }
    }
}
