using EducationCenter.Domain.Entities.Courses;
using TestEducationCenterUoW.Data.IRepositories;

namespace EducationCenter.Data.IRepositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
    }
}
