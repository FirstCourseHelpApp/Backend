using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {

        public Answer CreateAnswer(FirstCusrHelpAppContext dbContext, string text, Guid questionId)
        {
            var answer = new Answer
            {
                Id = Guid.NewGuid(),
                IsRightAnswer = false,
                QuestionId = questionId,
                Text = text
            };

            dbContext.Answers!.Add(answer);
            dbContext.SaveChanges();

            return answer;
        }

        public Answer CreateAnswer(FirstCusrHelpAppContext dbContext, string text)
        {
            var answer = new Answer
            {
                Id = Guid.NewGuid(),
                IsRightAnswer = false,
                Text = text
            };

            dbContext.Answers!.Add(answer);
            dbContext.SaveChanges();

            return answer;
        }

        public Answer GetAnswer(FirstCusrHelpAppContext dbContext, Guid answerId)
        {
            return dbContext.Answers!.FirstOrDefault(a => a.Id == answerId);
        }

        public ICollection<Answer> GetQuestionAnswers(FirstCusrHelpAppContext dbContext, Guid questionId)
        {
            return dbContext.Questions.FirstOrDefault(x => x.Id == questionId).Answers;
        }

        public bool SetRightAnswer(FirstCusrHelpAppContext dbContext, Guid questionId, Guid rightAnswerId)
        {
            var question = dbContext.Questions.FirstOrDefault(x => x.Id == questionId);
            if (question != null)
            {
                var answer = question.Answers.FirstOrDefault(x => x.Id == rightAnswerId);
                if (answer != null)
                {
                    answer.IsRightAnswer = true;

                    dbContext.Update(answer);
                    dbContext.SaveChanges();

                    return true;
                }
            }
            return false;
        }
    }
}
