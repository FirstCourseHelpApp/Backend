namespace Backend.DAL.Entities
{
    public class SubChapterProgress
    {
        public Guid Id { get; set; }

        public bool IsCompleted { get; set; }

        public User? User { get; set; }

        public Guid UserId { get; set; }

        public SubChapter? SubChapter { get; set; }

        public Guid SubChapterId { get; set; }
    }
}
