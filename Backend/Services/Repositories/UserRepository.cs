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
            return dbContext.Users.Include(u => u.UserProgress).FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByEmail(FirstCusrHelpAppContext dbContext, string email)
        {
            return dbContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public UserProgress GetUserProgress(FirstCusrHelpAppContext dbContext, Guid userId)
        {
            return dbContext.UsersProgress.FirstOrDefault(x => x.UserId == userId);
        }

        public IQueryable<User> GetUsers(FirstCusrHelpAppContext dbContext)
        {
            return dbContext.Users;
        }
    }
}
