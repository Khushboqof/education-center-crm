using EducationCenter.Domain.Entities.Departments;
using EducationCenter.Service.DTOs.Departaments;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EducationCenter.Service.Interfaces
{
    public interface IEmployeeSalaryService
    {
        Task<EmployeeSalary> CreateAsync(EmployeeSalaryForCreationDto employeeSalaryDto);
        Task<EmployeeSalary> GetAsync(Expression<Func<EmployeeSalary, bool>> expression);
        Task<IEnumerable<EmployeeSalary>> GetAllAsync(Expression<Func<EmployeeSalary, bool>> expression = null);
        Task<bool> DeleteAsync(Expression<Func<EmployeeSalary, bool>> expression);
        Task<EmployeeSalary> UpdateAsync(long id, EmployeeSalaryForCreationDto employeeSalaryDto);
    }
}
