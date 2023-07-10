using Backend.DAL.Entities;
using Backend.Services.Repositories;

namespace Backend.Controllers
{
    public class Mutation
    {
        private readonly IUserRepository _userRepository;
        private readonly IChapterRepository _chapterRepository;

        public Mutation(IUserRepository userRepository,
            IChapterRepository chapterRepository)
        {
            _userRepository = userRepository;
            _chapterRepository = chapterRepository;
        }

        public User CreateUser(string email, string password)
        {
            return _userRepository.CreateUser(email, password);
        }

        public Chapter CreateChapter(ICollection<SubChapter> subChapters, Test test)
        {
            return _chapterRepository.CreateChapter(subChapters, test);
        }
    }
}
