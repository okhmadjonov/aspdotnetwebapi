using aspdotnetwebapi.DbContext;
using aspdotnetwebapi.DTO;
using aspdotnetwebapi.Entities;
using aspdotnetwebapi.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace aspdotnetwebapi.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly DataContext _dataContext;

        public TestRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<Test> AddTest(TestDto testDto)
        {
            var test = testDto.Adapt<Test>();
            _dataContext.Tests.Add(test);
            await _dataContext.SaveChangesAsync();
            return test;
        }

        public async System.Threading.Tasks.Task DeleteTest(Guid id)
        {
            var deleteTest = await _dataContext.Tests.Include(x => x.Choices).FirstOrDefaultAsync(i => i.Id == id);
            if (deleteTest != null) _dataContext.Tests.Remove(deleteTest);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Test>> GetTestCollections()
        {
            return await _dataContext.Tests.Include(x => x.Choices).ToListAsync();
        }

        public async Task<Test?> UpdateTest(Guid id, TestDto testDto)
        {
            var updatedTest = await _dataContext.Tests.Include(x => x.Choices).FirstOrDefaultAsync(x => x.Id == id);

            if (updatedTest is null) return updatedTest;

            updatedTest.QuestionText = testDto.QuestionText;
            updatedTest.AnswerText = testDto.AnswerTest;
            updatedTest.Choices = testDto.Choices;

            await _dataContext.SaveChangesAsync();

            return updatedTest;
        }
    }
}
