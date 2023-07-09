using Backend.DAL.Entities;

namespace Backend.Services.Repositories
{
    public interface IUserRepository
    {
        public User CreateUser(string email, string encryptedPass);

        public User GetUser(Guid id);

        public User GetUserByEmail(string email);

        public ICollection<User> GetUsers();
    }
}
