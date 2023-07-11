using Backend.Services.Context;
using Backend.DAL.Entities;
using System.Linq;

namespace Backend.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        // public User CreateUser(FirstCusrHelpAppContext dbContext, string email, string password)
        // {
        //     var subChaptersProgresses = new List<SubChapterProgress>();
        //     var testsProgresses = new List<TestProgress>();
        //     
        //     var id = Guid.NewGuid();
        //     var user = new User() { Id = id, Email = email, Password = password, IsActive = true };
        //     dbContext.Users!.Add(user);
        //     
        //     var userProgress = new UserProgress() { Id = Guid.NewGuid(), UserId = id, User = user};
        //     dbContext.UsersProgress!.Add(userProgress);
        //
        //     foreach(var subChapter in dbContext.SubChapters)
        //     {
        //         subChaptersProgresses.Add(new SubChapterProgress() 
        //         { 
        //             Id = Guid.NewGuid(),
        //             IsCompleted = false,
        //             SubChapterId = subChapter.Id,
        //             SubChapter = subChapter,
        //             UserProgressId = userProgress.Id,
        //             UserProgress = userProgress
        //         });
        //     }
        //     dbContext.SubChapterProgresses!.AddRange(subChaptersProgresses);
        //
        //     foreach(var test in dbContext.Tests)
        //     {
        //         testsProgresses.Add(new TestProgress()
        //         {
        //             Id = Guid.NewGuid(),
        //             TestId = test.Id,
        //             Test = test,
        //             MaxScore = 0,
        //             UserProgressId = userProgress.Id,
        //             UserProgress = userProgress
        //         });
        //     }
        //     dbContext.TestProgresses!.AddRange(testsProgresses);
        //     
        //     dbContext.SaveChanges();
        //
        //     return user;
        // }

        public User CreateUser(FirstCusrHelpAppContext dbContext, string email, string password)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = password,
                IsActive = true
            };
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return user;
        }

        public User GetUser(FirstCusrHelpAppContext dbContext, Guid id)
        {
            return dbContext.Users.FirstOrDefault(x => x.Id == id);
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
