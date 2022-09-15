using EducationCenter.Data.IRepositories;
using EducationCenter.Domain.Entities.Teachers;
using TestEducationCenterUoW.Data.Repositories;

namespace EducationCenter.Data.Repositories
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {

    }
}
