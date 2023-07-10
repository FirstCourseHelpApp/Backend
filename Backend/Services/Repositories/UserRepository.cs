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
            var user = new User { Id = id, Email = email, Password = password, IsActive = true };
            var userProgress = new UserProgress { Id = Guid.NewGuid(), UserId = id};

            dbContext.Users.Add(user);
            dbContext.UsersProgress.Add(userProgress);
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

        public UserProgress GetUserProgress(FirstCusrHelpAppContext dbContext, Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetUsers(FirstCusrHelpAppContext dbContext)
        {
            return dbContext.Users;
        }
    }
}
