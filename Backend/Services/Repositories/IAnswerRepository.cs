using Backend.DAL.Entities;

namespace Backend.Services.Repositories
{
    public interface IAnswerRepository
    {
        public Answer CreateAnswer(string text, Question question);

        public bool SetRightAnswer(Guid QuestionId, Guid rightAnswerId);

        public ICollection<Answer> GetQuestionAnswers(Guid questionId);
    }
}
