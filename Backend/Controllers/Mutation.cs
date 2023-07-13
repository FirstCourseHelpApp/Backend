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

        public User CreateUserOld(FirstCusrHelpAppContext dbContext, string email, string password)
        {
            return _userRepository.CreateUser(dbContext, email, password);
        }

        public string RegisterUser(
            [Service] IAuthService authService,
            UserInput input) => authService.RegisterUser(input);
        
        public string AuthorizeUser(
            [Service] IAuthService authService,
            UserInput input) => authService.AuthorizeUser(input);

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
