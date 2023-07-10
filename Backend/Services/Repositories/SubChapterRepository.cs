using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public class SubChapterRepository : ISubChapterRepository
    {
        private readonly ApplicationContext _dbContext;

        public SubChapterRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SubChapter CreateSubChapter(string name, Guid chapterId)
        {
            var subChapter = new SubChapter
            {
                Id = Guid.NewGuid(),
                Name = name,
                ChapterId = chapterId
            };

            _dbContext.SubChapters.Add(subChapter);
            _dbContext.SaveChanges();

            return subChapter;
        }

        public SubChapter GetSubChapterById(Guid id)
        {
            return _dbContext.SubChapters.FirstOrDefault(x => x.Id == id);
        }

        public SubChapter GetSubChapterWithUserProgress(Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
