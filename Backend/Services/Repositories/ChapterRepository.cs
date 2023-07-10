using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public class ChapterRepository : IChapterRepository
    {

        public Chapter CreateChapter(FirstCusrHelpAppContext dbContext, int order)
        {
            var chapter = new Chapter
            {
                Id = Guid.NewGuid(),
                Order = order,
            };

            dbContext.Chapters.Add(chapter);
            dbContext.SaveChanges();

            return chapter;
        }

        public Chapter GetChapter(FirstCusrHelpAppContext dbContext, Guid id)
        {
            return dbContext.Chapters.FirstOrDefault(x => x.Id == id);
        }

        public Chapter GetChapterWithUserProgress(FirstCusrHelpAppContext dbContext, Guid chapterId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Chapter> GetChapters(FirstCusrHelpAppContext dbContext)
        {
            return dbContext.Chapters;
        }

        public Chapter SetTest(FirstCusrHelpAppContext dbContext, Guid chapterId, Guid testId)
        {
            throw new NotImplementedException();
        }

        public Chapter AddSubChapterToChupter(FirstCusrHelpAppContext dbContext, Guid subChapterId)
        {
            throw new NotImplementedException();
        }

        public Chapter RemoveSubChapterFromChupter(FirstCusrHelpAppContext dbContext, Guid subChapterId)
        {
            throw new NotImplementedException();
        }
    }
}
