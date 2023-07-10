namespace Backend.DAL.Entities
{
    public class TestProgress
    {
        public Guid Id { get; set; }

        public int MaxScore { get; set; }

        public Test? Test { get; set; }

        public Guid TestId { get; set; }

        public User? User { get; set; }

        public Guid UserId { get; set; }
    }
}
