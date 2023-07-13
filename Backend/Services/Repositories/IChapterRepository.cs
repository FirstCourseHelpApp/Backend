using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public interface IChapterRepository
    {
        public Chapter CreateChapter(FirstCusrHelpAppContext dbContext, int order);

        public Chapter SetTest(FirstCusrHelpAppContext dbContext, Guid chapterId, Guid testId); 

        public Chapter AddSubChapterToChupter(FirstCusrHelpAppContext dbContext, Guid subChapterId);

        public Chapter RemoveSubChapterFromChupter(FirstCusrHelpAppContext dbContext, Guid subChapterId);

        public Chapter GetChapter(FirstCusrHelpAppContext dbContext, Guid id);

        public IQueryable<Chapter> GetChapters(FirstCusrHelpAppContext dbContext);

        public Chapter GetChapterWithUserProgress(FirstCusrHelpAppContext dbContext, Guid chapterId, Guid userId);

        public IQueryable<Chapter> GetChaptersWithUserProgress(FirstCusrHelpAppContext dbContext, Guid userId);
    }
}
