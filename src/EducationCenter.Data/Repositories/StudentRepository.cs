using EducationCenter.Domain.Entities.Students;
using TestEducationCenterUoW.Data.IRepositories;

namespace TestEducationCenterUoW.Data.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {

    }
}
