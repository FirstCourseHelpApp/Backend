using Backend.Services.Context;
using Backend.DAL.Entities;

namespace Backend.Services.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationContext dbContext;
        public UserRepository(ApplicationContext context) { dbContext = context; }

        public User CreateUser(string email, string password)
        {
            var id = Guid.NewGuid();
            var user = new User { Id = id, Email = email, Password = password, PhoneNumber = "89123456789", IsActive = true };
            var userProgress = new UserProgress { Id = Guid.NewGuid(), UserId = id};

            dbContext.Users.Add(user);
            dbContext.UsersProgress.Add(userProgress);
            dbContext.SaveChanges();

            return user;
        }

        public User GetUser(Guid id)
        {
            return dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByEmail(string email)
        {
            return dbContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public ICollection<User> GetUsers()
        {
            return dbContext.Users.ToList();
        }
    }
}
