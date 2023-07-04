namespace Backend.Entities
{
    public class Answer
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public Question Question { get; set; }
    }
}
