using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public class ChapterRepository : IChapterRepository
    {
        private ApplicationContext _dbContext;

        public ChapterRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Chapter CreateChapter(ICollection<SubChapter> subChapters, Test test)
        {
            var chapter = new Chapter
            {
                Id = Guid.NewGuid(),
                SubChapters = subChapters,
                Test = test
            };

            _dbContext.Chapters.Add(chapter);
            _dbContext.SaveChanges();

            return chapter;
        }

        public Chapter GetChapterById(Guid id)
        {
            return _dbContext.Chapters.FirstOrDefault(x => x.Id == id);
        }

        public Chapter GetChapterByIdWithUserProgress(Guid chapterId, Guid userId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Chapter> GetChapters()
        {
            return _dbContext.Chapters.ToList();
        }
    }
}
