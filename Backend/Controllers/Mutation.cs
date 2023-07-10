using Backend.DAL.Entities;
using Backend.Services.Context;
using Backend.Services.Repositories;

namespace Backend.Controllers
{
    public class Mutation
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

        public Mutation(IAnswerRepository answerRepository,
            IChapterRepository chapterRepository,
            IPersonRepository personRepository,
            IPointRepository pointRepository,
            IQuestionRepository questionRepository,
            ISubChapterRepository subChapterRepository,
            ITermRepository termRepository,
            ITestRepository testRepository,
            IUserRepository userRepository,
            FirstCusrHelpAppContext firstCusrHelpAppContext)
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

        public User CreateUser(FirstCusrHelpAppContext dbContext, string email, string password)
        {
            return _userRepository.CreateUser(dbContext, email, password);
        }

        public Answer CreateAnswer(FirstCusrHelpAppContext dbContext, string answer, Guid questionId)
        {
            return _answerRepository.CreateAnswer(dbContext, answer, questionId);
        }

        public Chapter CreateChapter(FirstCusrHelpAppContext dbContext, int order)
        {
            return _chapterRepository.CreateChapter(dbContext, order);
        }
    }
}
