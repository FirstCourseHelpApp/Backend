using Backend.DAL.Entities;

namespace Backend.Services.Repositories
{
    public interface ITestRepository
    {
        public Test CreateTest(Guid chapterId, ICollection<Question> questions);

        public Test GetTest(Guid chapterId);

        public ICollection<Test> GetTests();
    }
}
