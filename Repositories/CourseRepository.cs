using aspdotnetwebapi.DbContext;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Services;

namespace aspdotnetwebapi.Repositories
{
    public class CourseRepository : GenericService<Course, DataContext>
    {
        public CourseRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
