using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public class SubChapterRepository : ISubChapterRepository
    {
        public SubChapter CreateSubChapter(FirstCusrHelpAppContext dbContext, string name, int order, Guid chapterId)
        {
            var subChapter = new SubChapter
            {
                Id = Guid.NewGuid(),
                Name = name,
                Order = order,
                ChapterId = chapterId
            };

            dbContext.SubChapters.Add(subChapter);
            dbContext.SaveChanges();

            return subChapter;
        }

        public SubChapter GetSubChapter(FirstCusrHelpAppContext dbContext, Guid id)
        {
            return dbContext.SubChapters.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<SubChapter> GetSubChaptersFromChapter(FirstCusrHelpAppContext dbContext, Guid chapterId)
        {
            return dbContext.SubChapters.Where(s => s.ChapterId == chapterId);
        }

        public SubChapter GetSubChapterWithUserProgress(FirstCusrHelpAppContext dbContext, Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }

        public SubChapter SetDocWay(FirstCusrHelpAppContext dbContext, Guid subChapterId, string docWay)
        {
            throw new NotImplementedException();
        }
    }
}
