using aspdotnetwebapi.DbContext;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Services;

namespace aspdotnetwebapi.Repositories
{
    public class DescCourseRepository : GenericService<DescCourse, DataContext>
    {
        public DescCourseRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
