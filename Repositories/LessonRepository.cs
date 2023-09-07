using aspdotnetwebapi.DbContext;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Services;

namespace aspdotnetwebapi.Repositories
{
    public class LessonRepository : GenericService<Lesson, DataContext>
    {
        public LessonRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
