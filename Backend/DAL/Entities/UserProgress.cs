namespace Backend.DAL.Entities
{
    public class UserProgress
    {
        public Guid Id { get; set; }

        public ICollection<SubChapterProgress> SubChapterProgresses { get; set; } = new List<SubChapterProgress>();

        public ICollection<TestProgress> TestProgresses { get; set; } = new List<TestProgress>();

        public User User { get; set; }

        public Guid UserId { get; set; }
    }
}
