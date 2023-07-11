namespace Backend.DAL.Entities
{
    public class TestProgress
    {
        public Guid Id { get; set; }

        public int MaxScore { get; set; }

        public Test? Test { get; set; }

        public Guid TestId { get; set; }

        public UserProgress UserProgress { get; set; }

        public Guid UserProgressId { get; set; }
    }
}
