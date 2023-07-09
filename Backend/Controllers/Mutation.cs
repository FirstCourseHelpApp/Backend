using Backend.DAL.Entities;
using Backend.Services.Repositories;

namespace Backend.Controllers
{
    public class Mutation
    {
        private readonly IUserRepository _userRepository;

        public Mutation(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(string email, string password)
        {
            var user = _userRepository.CreateUser(email, password);
            return user;
        }
    }
}
