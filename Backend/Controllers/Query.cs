using Backend.DAL.Entities;
using Backend.Services.Repositories;

namespace Backend.Controllers
{
    public class Query
    {
        private readonly IUserRepository _userRepository;

        public Query(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICollection<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }
    }
}
