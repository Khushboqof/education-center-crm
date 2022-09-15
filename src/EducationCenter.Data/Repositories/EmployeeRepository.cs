using EducationCenter.Data.IRepositories;
using EducationCenter.Domain.Entities.Departments;
using TestEducationCenterUoW.Data.Repositories;

namespace EducationCenter.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {

    }
}
