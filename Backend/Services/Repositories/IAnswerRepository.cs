using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public interface IAnswerRepository
    {
        public Answer CreateAnswer(FirstCusrHelpAppContext dbContext, string text, Guid questionId);

        public Answer CreateAnswer(FirstCusrHelpAppContext dbContext, string text);

        public bool SetRightAnswer(FirstCusrHelpAppContext dbContext, Guid QuestionId, Guid rightAnswerId);

        public Answer GetAnswer(FirstCusrHelpAppContext dbContext, Guid answerId);

        public ICollection<Answer> GetQuestionAnswers(FirstCusrHelpAppContext dbContext, Guid questionId);
    }
}
