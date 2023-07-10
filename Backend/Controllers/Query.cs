using Backend.DAL.Entities;
using Backend.Services.Repositories;

namespace Backend.Controllers
{
    public class Query
    {
        private readonly IUserRepository _userRepository;
        private readonly IChapterRepository _chapterRepository;

        public Query(IUserRepository userRepository,
            IChapterRepository chapterRepository)
        {
            _userRepository = userRepository;
            _chapterRepository = chapterRepository;
        }

        public ICollection<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public ICollection<Chapter> GetChapters()
        {
            return _chapterRepository.GetChapters();
        }

        public Chapter GetChapterById(Guid id)
        {
            return _chapterRepository.GetChapterById(id);
        }

        public User TestController()
        {
            return new User { Id = Guid.NewGuid(), Email = "mail@mail", Password = "1212" };
        }
    }
}
