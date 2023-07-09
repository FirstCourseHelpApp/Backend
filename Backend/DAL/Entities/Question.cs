namespace Backend.DAL.Entities
{
    public class Question
    {
        public Guid Id { get; set; }

        public string Theme { get; set; }

        public string QuestionText { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public Answer RightAnswer { get; set; }

        public Guid RightAnswerId { get; set; }
    }
}
