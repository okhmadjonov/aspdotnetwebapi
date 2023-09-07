using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using Task = System.Threading.Tasks.Task;
namespace aspdotnetwebapi.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact?>> GetContactAllAsync();
        Task<Contact?> GetContactByIdAsync(Guid id);
        Task<Contact> CreateContactAsync(ContactDto contactDto);
        Task<Contact?> UpdateContactAsync(string fullName, ContactDto contactDto);
        Task DeleteContactAsync(Guid id);
    }
}
