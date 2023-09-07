using aspdotnetwebapi.DbContext;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Services;

namespace aspdotnetwebapi.Repositories
{
    public class ReviewRepository : GenericService<Review, DataContext>
    {
        public ReviewRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
