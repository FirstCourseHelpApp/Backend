using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public interface ITermRepository
    {
        public Term CreateTerm(FirstCusrHelpAppContext dbContext, string word, string explanation);

        public Term GetTerm(FirstCusrHelpAppContext dbContext, Guid id);

        public IQueryable<Term> GetTerms(FirstCusrHelpAppContext dbContext);
    }
}
