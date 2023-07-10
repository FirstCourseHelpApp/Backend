namespace Backend.DAL.Entities
{
    public class Answer
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public bool IsRightAnswer { get; set; }

        public Question Question { get; set; }

        public Guid QuestionId { get; set; }
    }
}
