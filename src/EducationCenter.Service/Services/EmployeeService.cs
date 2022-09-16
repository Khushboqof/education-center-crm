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
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository employeeRepository;

        public EmployeeService()
        {
            this.employeeRepository = new EmployeeRepository();
        }

        public async Task<Employee> CreateAsync(EmployeeForCreationDto employeetDto)
        {

            var result = await employeeRepository.CreateAsync(employeetDto.Adapt<Employee>());

            await employeeRepository.SaveAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Employee, bool>> expression)
        {
            var isDeleted = await employeeRepository.DeleteAsync(expression);
            await employeeRepository.SaveAsync();
            return isDeleted;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> expression = null)
            => await employeeRepository.GetAllAsync(expression);

        public async Task<Employee> GetAsync(Expression<Func<Employee, bool>> expression)
        {
            var employee = await employeeRepository.GetAsync(expression);
            return employee;
        }

        public async Task<Employee> UpdateAsync(long id, EmployeeForCreationDto employeeDto)
        {
            var employee = await employeeRepository.GetAsync(p => p.Id == id);

            var result = await employeeRepository.UpdateAsync(employeeDto.Adapt(employee));

            await employeeRepository.SaveAsync();

            return result;
        }
    }
}
