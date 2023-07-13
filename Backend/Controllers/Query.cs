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

        //return single entity
        public Chapter GetChapterWithUserProgress(FirstCusrHelpAppContext dbContext, Guid chapterId, Guid userId) =>
            _chapterRepository.GetChapterWithUserProgress(dbContext, chapterId, userId);
        
        public Chapter GetChapter(FirstCusrHelpAppContext dbContext, Guid chapterId)
            => _chapterRepository.GetChapter(dbContext, chapterId);
        
        public SubChapter GetSubChapter(FirstCusrHelpAppContext dbContext, Guid chapterId) =>
            _subChapterRepository.GetSubChapter(dbContext, chapterId);

        public Question GetQuestion(FirstCusrHelpAppContext dbContext, Guid questionId) =>
            _questionRepository.GetQuestion(dbContext, questionId); 
        
        public Term GetTerm(FirstCusrHelpAppContext dbContext, Guid termId) => 
                _termRepository.GetTerm(dbContext, termId);
        
        public User GetUser(FirstCusrHelpAppContext dbContext, Guid userId) => 
                _userRepository.GetUser(dbContext, userId);

        public int GetGlobalUserProgress(FirstCusrHelpAppContext dbContext, Guid userId) => 
                _userRepository.GetGlobalUserProgressPercent(dbContext, userId);


        //return collections of entities
        public IQueryable<SubChapter> GetSubChaptersFromChapter(FirstCusrHelpAppContext dbContext, Guid chapterId) =>
            _subChapterRepository.GetSubChaptersFromChapter(dbContext, chapterId);
        
        public IQueryable<Chapter> GetChapters(FirstCusrHelpAppContext dbContext) =>
            _chapterRepository.GetChapters(dbContext);
        
        public IQueryable<User> GetUsers(FirstCusrHelpAppContext dbContext) => _userRepository.GetUsers(dbContext);
        
        public IQueryable<Term> GetTerms(FirstCusrHelpAppContext dbContext) => _termRepository.GetTerms(dbContext);

        public IQueryable<Person> GetPersons(FirstCusrHelpAppContext dbContext) =>
            _personRepository.GetPersons(dbContext);

        public IQueryable<Question> GetQuestions(FirstCusrHelpAppContext dbContext) =>
            _questionRepository.GetQuestions(dbContext);

        public IQueryable<Chapter> GetChaptersWithUserProgress(FirstCusrHelpAppContext dbContext, Guid userId) =>
            _chapterRepository.GetChaptersWithUserProgress(dbContext, userId);
        // public string DBAdd(FirstCusrHelpAppContext dbContext) => AddingEntitiesToDb.AddTerms(dbContext);
    }
}
