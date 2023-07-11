namespace Backend.DAL.Entities
{
    public class SubChapterProgress
    {
        public Guid Id { get; set; }

        public bool IsCompleted { get; set; }

        public SubChapter? SubChapter { get; set; }

        public Guid SubChapterId { get; set; }

        public UserProgress? UserProgress { get; set; }

        public Guid UserProgressId { get; set; }
    }
}
