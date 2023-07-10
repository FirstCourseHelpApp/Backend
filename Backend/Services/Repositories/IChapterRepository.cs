using Backend.DAL.Entities;

namespace Backend.Services.Repositories
{
    public interface IChapterRepository
    {
        public Chapter CreateChapter(ICollection<SubChapter> subChapters, Test test);

        public Chapter GetChapterById(Guid id);

        public ICollection<Chapter> GetChapters();

        public Chapter GetChapterByIdWithUserProgress(Guid chapterId, Guid userId);
    }
}
