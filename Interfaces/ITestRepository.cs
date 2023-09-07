using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;

namespace aspdotnetwebapi.Interfaces;
using Task = System.Threading.Tasks.Task;


public interface ITestRepository
{
    Task<List<Test>> GetTestCollections();
    Task<Test> AddTest(TestDto testDto);
    Task<Test?> UpdateTest(Guid id, TestDto testDto);
    Task DeleteTest(Guid id);
}

