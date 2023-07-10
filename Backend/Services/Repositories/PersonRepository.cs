using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public Person CreatePerson(FirstCusrHelpAppContext dbContext, string name, string description, string photoWay)
        {
            throw new NotImplementedException();
        }

        public Person CreatePerson(FirstCusrHelpAppContext dbContext, string name)
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(FirstCusrHelpAppContext dbContext, Guid personId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Person> GetPersons(FirstCusrHelpAppContext dbContext)
        {
            throw new NotImplementedException();
        }

        public Person SetDescription(FirstCusrHelpAppContext dbContext, Guid personId, string Description)
        {
            throw new NotImplementedException();
        }

        public Person SetPhotoWay(FirstCusrHelpAppContext dbContext, Guid personId, string photoWay)
        {
            throw new NotImplementedException();
        }
    }
}
