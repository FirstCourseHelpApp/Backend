using Backend.DAL.Entities;

namespace Backend.Services.Repositories
{
    public interface ISubChapterRepository
    {
        public SubChapter CreateSubChapter(string name, Guid chapterId);

        public SubChapter GetSubChapterById(Guid id);

        public SubChapter GetSubChapterWithUserProgress(Guid id, Guid userId);
    }
}
