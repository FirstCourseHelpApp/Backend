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

        public Term GetTerm(FirstCusrHelpAppContext dbContext)
        {
            throw new NotImplementedException();
        }

        public ICollection<Term> GetTerms(FirstCusrHelpAppContext dbContext)
        {
            throw new NotImplementedException();
        }
    }
}
