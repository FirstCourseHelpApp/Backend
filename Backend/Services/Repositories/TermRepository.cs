using Backend.DAL.Entities;
using Backend.Services.Context;

namespace Backend.Services.Repositories
{
    public class TermRepository : ITermRepository
    {
        public Term CreateTerm(FirstCusrHelpAppContext dbContext, string word, string explanation)
        {
            throw new NotImplementedException();
        }

        public Term GetTerm(FirstCusrHelpAppContext dbContext, Guid id)
        {
            return dbContext.Terms.FirstOrDefault(t => t.Id == id);
        }

        public IQueryable<Term> GetTerms(FirstCusrHelpAppContext dbContext)
        {
            return dbContext.Terms;
        }
    }
}
