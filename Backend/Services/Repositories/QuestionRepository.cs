using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationContext _dbContext;

        public QuestionRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Question CreateQuestion(string questionText, ICollection<Answer> answers, Guid testId)
        {
            var question = new Question
            {
                Id = Guid.NewGuid(),
                QuestionText = questionText,
                TestId = testId,
                Answers = answers
            };

            _dbContext.Questions.Add(question);
            _dbContext.SaveChanges();

            return question;
        }

        public Question GetQuestion(Guid id)
        {
            return _dbContext.Questions.FirstOrDefault(x => x.Id == id);
        }

        public ICollection<Question> GetQuestions()
        {
            return _dbContext.Questions.ToList();
        }
    }
}
