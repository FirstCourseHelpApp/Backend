using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public interface ITestRepository
    {
        public Test CreateTest(FirstCusrHelpAppContext dbContext, int order, Guid chapterId);

        public Test GetTest(FirstCusrHelpAppContext dbContext, Guid chapterId);

        public Test AddQuestionToTest(FirstCusrHelpAppContext dbContext, Guid testId, Guid questionId);

        public Test RemoveQuestionFromTest(FirstCusrHelpAppContext dbContext, Guid testId, Guid questionId);

        public IQueryable<Test> GetTests(FirstCusrHelpAppContext dbContext);
    }
}
