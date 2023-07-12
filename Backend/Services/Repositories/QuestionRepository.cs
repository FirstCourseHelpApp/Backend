using Backend.DAL.Entities;
using Backend.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        public Question AddAnswerToQuestion(FirstCusrHelpAppContext dbContext, Guid questionId, Guid AnswerId)
        {
            throw new NotImplementedException();
        }

        public Question CreateQuestion(FirstCusrHelpAppContext dbContext, string questionText, Guid testId)
        {
            var question = new Question
            {
                Id = Guid.NewGuid(),
                QuestionText = questionText,
                TestId = testId,
            };

            dbContext.Questions.Add(question);
            dbContext.SaveChanges();

            return question;
        }

        public Question GetQuestion(FirstCusrHelpAppContext dbContext, Guid id)
        {
            return dbContext.Questions.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Question> GetQuestions(FirstCusrHelpAppContext dbContext)
        {
            return dbContext.Questions.Include(q => q.Answers);
        }

        public Question RemoveAnswerFromQuestion(FirstCusrHelpAppContext dbContext, Guid questionId, Guid AnswerId)
        {
            throw new NotImplementedException();
        }
    }
}
