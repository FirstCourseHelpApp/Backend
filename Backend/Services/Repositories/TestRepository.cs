using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public class TestRepository : ITestRepository
    {
        public Test AddQuestionToTest(FirstCusrHelpAppContext dbContext, Guid testId, Guid questionId)
        {
            throw new NotImplementedException();
        }

        public Test CreateTest(FirstCusrHelpAppContext dbContext, int order, Guid chapterId)
        {
            var test = new Test
            {
                Id = Guid.NewGuid(),
                Order = order,
                ChapterId = chapterId,
            };

            dbContext.Tests.Add(test);
            dbContext.SaveChanges();

            return test;
        }

        public Test GetTest(FirstCusrHelpAppContext dbContext, Guid chapterId)
        {
            return dbContext.Tests.FirstOrDefault(x => x.ChapterId == chapterId);
        }

        public IQueryable<Test> GetTests(FirstCusrHelpAppContext dbContext)
        {
            return dbContext.Tests;
        }

        public Test RemoveQuestionFromTest(FirstCusrHelpAppContext dbContext, Guid testId, Guid questionId)
        {
            throw new NotImplementedException();
        }
    }
}
