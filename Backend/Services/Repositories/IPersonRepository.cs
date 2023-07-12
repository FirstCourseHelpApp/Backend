using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public interface IPersonRepository
    {
        public Person CreatePerson(FirstCusrHelpAppContext dbContext, string name, string description, string photoWay);

        public Person CreatePerson(FirstCusrHelpAppContext dbContext, string name);

        public Person SetDescription(FirstCusrHelpAppContext dbContext, Guid personId, string Description);

        public Person SetPhotoWay(FirstCusrHelpAppContext dbContext, Guid personId, string photoWay);

        public Person GetPerson(FirstCusrHelpAppContext dbContext, Guid personId);

        public IQueryable<Person> GetPersons(FirstCusrHelpAppContext dbContext);
    }
}
