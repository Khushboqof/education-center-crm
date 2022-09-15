
using EducationCenter.Data.IRepositories;
using EducationCenter.Domain.Entities.Courses;
using TestEducationCenterUoW.Data.Repositories;

namespace EducationCenter.Data.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {

    }

}
