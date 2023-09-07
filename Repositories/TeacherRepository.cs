using aspdotnetwebapi.DbContext;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Services;

namespace aspdotnetwebapi.Repositories
{
    public class TeacherRepository : GenericService<Teacher, DataContext>
    {

        public TeacherRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
