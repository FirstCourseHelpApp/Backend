using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public class TestRepository : ITestRepository
    {
        private ApplicationContext _dbContext;

        public TestRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Test CreateTest(Guid chapterId, ICollection<Question> questions)
        {
            var test = new Test
            {
                Id = Guid.NewGuid(),
                ChapterId = chapterId,
                Questions = questions
            };

            _dbContext.Tests.Add(test);
            _dbContext.SaveChanges();

            return test;
        }

        public Test GetTest(Guid chapterId)
        {
            return _dbContext.Tests.FirstOrDefault(x => x.ChapterId == chapterId);
        }

        public ICollection<Test> GetTests()
        {
            return _dbContext.Tests.ToList();
        }
    }
}
