using Backend.DAL.Entities;
using Backend.Services.Context;
using Microsoft.EntityFrameworkCore;

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
            return dbContext.Chapters.Include(c => c.SubChapters.OrderBy(sc =>sc.Order))
                .FirstOrDefault(x => x.Id == id);
        }

        public Chapter GetChapterWithUserProgress(FirstCusrHelpAppContext dbContext, Guid chapterId, Guid userId)
        {
            var chapter = dbContext.Chapters
                .Include(c => c.SubChapters)
                .FirstOrDefault(c => c.Id == chapterId);
            
            var userProgress = dbContext.UsersProgress
                .Include(up => up.SubChapterProgresses)
                .Include(up => up.TestProgresses)
                .FirstOrDefault(u => u.UserId == userId);

            foreach(var subChapter in chapter.SubChapters)
            {
                subChapter.IsCompleted = userProgress.SubChapterProgresses
                    .FirstOrDefault(s => s.SubChapterId == subChapter.Id).IsCompleted; 
            }

            chapter.SubChapters.OrderBy(sc => sc.Order);

            return chapter;
        }

        public IQueryable<Chapter> GetChapters(FirstCusrHelpAppContext dbContext)
        {
            return dbContext.Chapters
                .Include(c => c.SubChapters.OrderBy(sc => sc.Order))
                .OrderBy(c => c.Order)
                .Include(C => C.Test);
        }
        
        public IQueryable<Chapter> GetChaptersWithUserProgress(FirstCusrHelpAppContext dbContext, Guid userId)
        {
            var chapters = dbContext.Chapters
                .Include(c => c.SubChapters.OrderBy(sc => sc.Order))
                .Include(c => c.Test)
                .OrderBy(c => c.Order);

            var userProgress = dbContext.UsersProgress
                .Include(up => up.SubChapterProgresses)
                .Include(up => up.TestProgresses)
                .FirstOrDefault(up => up.UserId == userId);

            foreach (var chapter in chapters)
            {
                foreach (var subChapter in chapter.SubChapters)
                {
                    subChapter.IsCompleted = userProgress.SubChapterProgresses
                        .FirstOrDefault(scp => scp.SubChapterId == subChapter.Id).IsCompleted;
                }

                chapter.Test.MaxScore = userProgress.TestProgresses
                    .FirstOrDefault(tp => tp.TestId == chapter.Test.Id)
                    .MaxScore;
            }

            return chapters;
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
