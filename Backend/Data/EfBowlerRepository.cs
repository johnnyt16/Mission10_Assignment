using Microsoft.EntityFrameworkCore;

namespace Mission10Backend.Data
{
    public interface IBowlerRepository
    {
        IEnumerable<Bowler> GetBowlersWithTeams(string[] teamNames);
    }
    
    public class EfBowlerRepository : IBowlerRepository
    {
        private BowlerDbContext _context;
        
        public EfBowlerRepository(BowlerDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Bowler> GetBowlersWithTeams(string[] teamNames)
        {
            return _context.Bowlers
                .Include(b => b.Team)
                .Where(b => teamNames.Contains(b.Team.TeamName))
                .ToList();
        }
    }
}