using Backend.DAL.Entities;

namespace Backend.Services.Repositories
{
    public interface IQuestionRepository
    {
        public Question CreateQuestion(string question, ICollection<Answer> answers, Guid testId);

        public Question GetQuestion(Guid id);

        public ICollection<Question> GetQuestions();
    }
}
