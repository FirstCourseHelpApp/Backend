namespace Backend.DAL.Entities
{
    public class Question
    {
        public Guid Id { get; set; }

        public Test Test { get; set; }

        public Guid TestId { get; set; }

        public string QuestionText { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
