using Backend.Services.Context;
using Backend.DAL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User CreateUser(FirstCusrHelpAppContext dbContext, string email, string password)
        {
            var user = dbContext.Users?.Add(new User 
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = password,
                IsActive = true
            }).Entity;

            var userProgress = new UserProgress() { Id = Guid.NewGuid(), UserId = user.Id };

            foreach (var subChapter in dbContext.SubChapters)
            {
                userProgress.SubChapterProgresses.Add(new SubChapterProgress()
                {
                    Id = Guid.NewGuid(),
                    IsCompleted = false,
                    SubChapterId = subChapter.Id,
                    UserProgressId = userProgress.UserId
                });
            }

            foreach (var test in dbContext.Tests)
            {
                userProgress.TestProgresses.Add(new TestProgress()
                {
                    Id = Guid.NewGuid(),
                    MaxScore = 0,
                    UserProgressId = userProgress.Id,
                    TestId = test.Id
                });
            }
			
            dbContext.UsersProgress.Add(userProgress);
            dbContext.SaveChanges();
        
            return user;
        }

        public User GetUser(FirstCusrHelpAppContext dbContext, Guid id)
        {
            return dbContext.Users
                .Include(u => u.UserProgress)
                .ThenInclude(up => up.SubChapterProgresses)
                .Include( u => u.UserProgress)
                .ThenInclude(up => up.TestProgresses)
                .FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByEmail(FirstCusrHelpAppContext dbContext, string email)
        {
            return dbContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public UserProgress GetUserProgress(FirstCusrHelpAppContext dbContext, Guid userId)
        {
            return dbContext.UsersProgress.FirstOrDefault(x => x.UserId == userId);
        }

        public SubChapterProgress UpdateSubChapterProgress(FirstCusrHelpAppContext dbContext, Guid subChapterId, Guid userId)
        {
            var subChapterProgress = dbContext.UsersProgress
                    .Include(up => up.SubChapterProgresses)
                    .FirstOrDefault(up => up.UserId == userId).SubChapterProgresses
                    .FirstOrDefault(scp => scp.SubChapterId == subChapterId);
            
            subChapterProgress.IsCompleted = true;
            dbContext.SaveChanges();
            return subChapterProgress;
        }

        public TestProgress UpdateTestProgress(FirstCusrHelpAppContext dbContext,Guid testId, int maxScore, Guid userId)
        {
            var testProgress = dbContext.UsersProgress
                .Include(up => up.TestProgresses)
                .FirstOrDefault(up => up.UserId == userId).TestProgresses
                .FirstOrDefault(tp => tp.TestId == testId);

            testProgress.MaxScore = maxScore;
            dbContext.SaveChanges();
            return testProgress;
        }

        public IQueryable<User> GetUsers(FirstCusrHelpAppContext dbContext)
        {
            return dbContext.Users;
        }

        public int GetGlobalUserProgressPercent(FirstCusrHelpAppContext dbContext, Guid id)
        {
            var user = GetUser(dbContext, id);
            
            var total = 1.0;
            var done = 1.0;

            foreach (var subChapterProgress in user.UserProgress.SubChapterProgresses)
            {
                total += 1;
                if (subChapterProgress.IsCompleted) done += 1;
            }

            foreach (var testProgress in user.UserProgress.TestProgresses)
            {
                total += 5;
                done += testProgress.MaxScore;
            }

            return Convert.ToInt32(done / total * 100);
        }
    }
}
