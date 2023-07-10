using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public interface IPointRepository
    {
        public Point CreatePoint(FirstCusrHelpAppContext dbContext, float x, float y, string name, string description, string photoWay);

        public Point CreatePoint(FirstCusrHelpAppContext dbContext, float x, float y, string name);

        public Point SetDescription(FirstCusrHelpAppContext dbContext, Guid pointId, string description);

        public Point SetPhotoWay(FirstCusrHelpAppContext dbContext, Guid pointId, string photoWay);

        public Point GetPoint(FirstCusrHelpAppContext dbContext, Guid pointId);

        public ICollection<Point> GetPoints(FirstCusrHelpAppContext dbContext);
    }
}
