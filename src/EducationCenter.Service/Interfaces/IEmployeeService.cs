using EducationCenter.Domain.Entities.Departments;
using EducationCenter.Service.DTOs.Departaments;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationCenter.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> CreateAsync(EmployeeForCreationDto employeeDto);
        Task<Employee> GetAsync(Expression<Func<Employee, bool>> expression);
        Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> expression = null);
        Task<bool> DeleteAsync(Expression<Func<Employee, bool>> expression);
        Task<Employee> UpdateAsync(long id, EmployeeForCreationDto employeeDto);
    }
}
