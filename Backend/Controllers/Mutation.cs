using Backend.DAL.Auth;
using Backend.DAL.Entities;
using Backend.Services.Auth;
using Backend.Services.Context;
using Backend.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
        private readonly IAuthService _authService;

        public Mutation(IAnswerRepository answerRepository,
            IChapterRepository chapterRepository,
            IPersonRepository personRepository,
            IPointRepository pointRepository,
            IQuestionRepository questionRepository,
            ISubChapterRepository subChapterRepository,
            ITermRepository termRepository,
            ITestRepository testRepository,
            IUserRepository userRepository,
            IAuthService authService)
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
            _authService = authService;
        }

        public string RegisterUser(
            [Service] IAuthService authService,
            UserInput input) => authService.RegisterUser(input);
        
        public string AuthorizeUser(
            [Service] IAuthService authService,
            UserInput input) => authService.AuthorizeUser(input);

        public Answer CreateAnswer(FirstCusrHelpAppContext dbContext, string answer, Guid questionId)
            => _answerRepository.CreateAnswer(dbContext, answer, questionId);

        public Chapter CreateChapter(FirstCusrHelpAppContext dbContext, int order)
            => _chapterRepository.CreateChapter(dbContext, order);

        public SubChapterProgress UpdateUserSubChapterProgress(FirstCusrHelpAppContext dbContext, Guid subChapterId, Guid userId)
            => _userRepository.UpdateSubChapterProgress(dbContext, subChapterId, userId);
        
        public TestProgress UpdateUserTestProgress(FirstCusrHelpAppContext dbContext, Guid testId, int maxScore, Guid userId)
            => _userRepository.UpdateTestProgress(dbContext, testId, maxScore, userId);
    }
}
