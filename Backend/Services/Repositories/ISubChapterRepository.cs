using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public interface ISubChapterRepository
    {
        public SubChapter CreateSubChapter(FirstCusrHelpAppContext dbContext, string name, int order, Guid chapterId);

        public SubChapter SetDocWay(FirstCusrHelpAppContext dbContext, Guid subChapterId, string docWay);

        public SubChapter GetSubChapter(FirstCusrHelpAppContext dbContext, Guid id);

        public IQueryable<SubChapter> GetSubChaptersFromChapter(FirstCusrHelpAppContext dbContext, Guid chapterId);

        public SubChapter GetSubChapterWithUserProgress(FirstCusrHelpAppContext dbContext, Guid id, Guid userId);
    }
}
