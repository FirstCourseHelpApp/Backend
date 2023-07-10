using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public interface IQuestionRepository
    {
        public Question CreateQuestion(FirstCusrHelpAppContext dbContext, string question, Guid testId);

        public Question AddAnswerToQuestion(FirstCusrHelpAppContext dbContext, Guid questionId, Guid AnswerId);

        public Question RemoveAnswerFromQuestion(FirstCusrHelpAppContext dbContext, Guid questionId, Guid AnswerId);

        public Question GetQuestion(FirstCusrHelpAppContext dbContext, Guid id);

        public ICollection<Question> GetQuestions(FirstCusrHelpAppContext dbContext);
    }
}
