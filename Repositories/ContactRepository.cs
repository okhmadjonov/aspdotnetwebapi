using aspdotnetwebapi.DbContext;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Services;

namespace aspdotnetwebapi.Repositories
{
    public class ContactRepository : GenericService<Contact, DataContext>
    {
        public ContactRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
