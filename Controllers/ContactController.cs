using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace aspdotnetwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ContactController : DbController<Contact, ContactRepository>
    {
        public ContactController(ContactRepository repository) : base(repository)
        {

        }
    }
}
