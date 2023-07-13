using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public interface IUserRepository
    {
        public User CreateUser(FirstCusrHelpAppContext dbContext, string email, string encryptedPass);
        
        public UserProgress GetUserProgress(FirstCusrHelpAppContext dbContext, Guid userId);

        public User GetUser(FirstCusrHelpAppContext dbContext, Guid userId);

        public User GetUserByEmail(FirstCusrHelpAppContext dbContext, string email);

        public IQueryable<User> GetUsers(FirstCusrHelpAppContext dbContext);

        public int GetGlobalUserProgressPercent(FirstCusrHelpAppContext dbContext, Guid userId);

        public SubChapterProgress UpdateSubChapterProgress(FirstCusrHelpAppContext dbContext,Guid subChapterId, Guid userId);

        public TestProgress UpdateTestProgress(FirstCusrHelpAppContext dbContext,Guid testId, int maxScore, Guid userId);
    }
}
