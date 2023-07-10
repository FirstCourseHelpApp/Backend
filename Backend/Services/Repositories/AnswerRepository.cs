using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationContext _dbContext;

        public AnswerRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Answer CreateAnswer(string text, Question question)
        {
            var answer = new Answer
            {
                Id = Guid.NewGuid(),
                IsRightAnswer = false,
                Question = question,
                Text = text
            };

            _dbContext.Answers.Add(answer);
            _dbContext.SaveChanges();

            return answer;
        }

        public ICollection<Answer> GetQuestionAnswers(Guid questionId)
        {
            return _dbContext.Questions.FirstOrDefault(x => x.Id == questionId).Answers;
        }

        public bool SetRightAnswer(Guid questionId, Guid rightAnswerId)
        {
            var question = _dbContext.Questions.FirstOrDefault(x => x.Id == questionId);
            if (question != null)
            {
                var answer = question.Answers.FirstOrDefault(x => x.Id == rightAnswerId);
                if (answer != null)
                {
                    answer.IsRightAnswer = true;

                    _dbContext.Update(answer);
                    _dbContext.SaveChanges();

                    return true;
                }
            }
            return false;
        }
    }
}
