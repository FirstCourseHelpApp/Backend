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
    }
}
