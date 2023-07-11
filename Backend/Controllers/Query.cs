using Backend.DAL.Entities;
using Backend.Services.Context;
using Backend.Services.Repositories;

namespace Backend.Controllers
{
    public class Query
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IChapterRepository _chapterRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPointRepository _pointRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ISubChapterRepository _subChapterRepository;
        private readonly ITermRepository _termRepository;
        private readonly ITestRepository _testRepository;
        private readonly IUserRepository _userRepository;

        public Query(IAnswerRepository answerRepository,
            IChapterRepository chapterRepository,
            IPersonRepository personRepository,
            IPointRepository pointRepository,
            IQuestionRepository questionRepository,
            ISubChapterRepository subChapterRepository,
            ITermRepository termRepository,
            ITestRepository testRepository,
            IUserRepository userRepository)
        {
            _answerRepository = answerRepository;
            _chapterRepository = chapterRepository;
            _personRepository = personRepository;
            _pointRepository = pointRepository;
            _questionRepository = questionRepository;
            _subChapterRepository = subChapterRepository;
            _termRepository = termRepository;
            _testRepository = testRepository;
            _userRepository = userRepository;
        }

        public IQueryable<User> GetUsers(FirstCusrHelpAppContext dbContext)
        {
            return _userRepository.GetUsers(dbContext);
        }

        public IQueryable<Chapter> GetChapters(FirstCusrHelpAppContext dbContext)
        {
            return _chapterRepository.GetChapters(dbContext);
        }

        public Chapter GetChapter(FirstCusrHelpAppContext dbContext, Guid id)
        {
            return _chapterRepository.GetChapter(dbContext, id);
        }

        public SubChapter GetSubChapter(FirstCusrHelpAppContext dbContext, Guid id)
        {
            return _subChapterRepository.GetSubChapter(dbContext, id);
        }

        public IQueryable<SubChapter> GetSubChaptersFromChapter(FirstCusrHelpAppContext dbContext, Guid chapterId)
        {
            return _subChapterRepository.GetSubChaptersFromChapter(dbContext, chapterId);
        }


    }
}
