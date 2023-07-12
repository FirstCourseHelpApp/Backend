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
            var term = dbContext.Terms.FirstOrDefault(t => t.Id == id);
            return term;
        }

        public IQueryable<Term> GetTerms(FirstCusrHelpAppContext dbContext)
        {
            return dbContext.Terms;
        }
    }
}
