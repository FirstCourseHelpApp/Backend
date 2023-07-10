using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public class PointRepository : IPointRepository
    {
        public Point CreatePoint(FirstCusrHelpAppContext dbContext, float x, float y, string name, string description, string photoWay)
        {
            throw new NotImplementedException();
        }

        public Point CreatePoint(FirstCusrHelpAppContext dbContext, float x, float y, string name)
        {
            throw new NotImplementedException();
        }

        public Point GetPoint(FirstCusrHelpAppContext dbContext, Guid pointId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Point> GetPoints(FirstCusrHelpAppContext dbContext)
        {
            throw new NotImplementedException();
        }

        public Point SetDescription(FirstCusrHelpAppContext dbContext, Guid pointId, string description)
        {
            throw new NotImplementedException();
        }

        public Point SetPhotoWay(FirstCusrHelpAppContext dbContext, Guid pointId, string photoWay)
        {
            throw new NotImplementedException();
        }
    }
}
