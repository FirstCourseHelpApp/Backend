using Backend.Services.Context;
using Backend.DAL.Entities;
using System.Linq;

namespace Backend.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User CreateUser(FirstCusrHelpAppContext dbContext, string email, string password)
        {
            var id = Guid.NewGuid();
            
            var user = new User() { Id = id, Email = email, Password = password, IsActive = true };
            var userProgress = new UserProgress() { Id = Guid.NewGuid(), UserId = id, User = user};

            var subChapters = dbContext.SubChapters;
            var tests = dbContext.Tests;

            var subChapterProgresses = new List<SubChapterProgress>();

            foreach (var subChapter in subChapters)
            {
                subChapterProgresses!.Add(new SubChapterProgress()
                {
                    Id = Guid.NewGuid(),
                    IsCompleted = false,
                    UserProgress = userProgress,
                    UserProgressId = userProgress.UserId,
                    SubChapter = subChapter,
                    SubChapterId = subChapter.ChapterId
                });
            }
            
            dbContext.Users!.Add(user);
            dbContext.UsersProgress!.Add(userProgress);
            dbContext.SubChapterProgresses!.AddRange(subChapterProgresses);
            dbContext.SaveChanges();
        
            return user;
        }

        public User CreateUser(FirstCusrHelpAppContext dbContext, string email, string phoneNumber, string password)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = email,
                PhoneNumber = phoneNumber,
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
